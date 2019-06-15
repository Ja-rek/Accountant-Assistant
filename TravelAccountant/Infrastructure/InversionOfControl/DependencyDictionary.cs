using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace TravelAccountant.Infrastructure.InversionOfControl
{
    public class DependencyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        private readonly IComponentContext context;

        public DependencyDictionary(IComponentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (context.TryResolveService(GetService(key), out object result))
            {
                value = (TValue)result;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var service in GetServices())
            {
                yield return new KeyValuePair<TKey, TValue>((TKey)service.ServiceKey, 
                    (TValue)context.ResolveService(GetService((TKey)service.ServiceKey)));
            }
        }

        public TValue this[TKey key] => (TValue)context.ResolveService(GetService(key));
        public bool ContainsKey(TKey key) => context.IsRegisteredWithKey<TValue>(key);
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        public IEnumerable<TKey> Keys => GetServices().Select(ks => ks.ServiceKey).Cast<TKey>();
        public int Count => GetServices().Count();
        public IEnumerable<TValue> Values => GetServices().Select(ks => 
            (TValue)context.ResolveService(GetService((TKey)ks.ServiceKey)));

        private static KeyedService GetService(TKey key) => new KeyedService(key, typeof(TValue));

        private IEnumerable<KeyedService> GetServices() 
        {
            return context.ComponentRegistry
                .Registrations
                .SelectMany(r => r.Services)
                .OfType<KeyedService>()
                .Where(ks => ks.ServiceKey.GetType() == typeof(TKey) && ks.ServiceType == typeof(TValue));
        }


    }
}
