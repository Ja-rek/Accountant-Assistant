using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;

namespace Common.Utils
{
    public static class AutofacExtensionMethods 
    {
        public static void RegisterInstancesWithAllStratiegies<TService,TStrategy>(this ContainerBuilder builder,
                Action<IRegistrationBuilder<object, SimpleActivatorData, SingleRegistrationStyle>> regiterAs)
        {
            var strategyTypes = GetTypesAsignableTo(typeof(TStrategy));

            foreach (var strategy in strategyTypes)
            {
                var strategyInstance = Activator.CreateInstance(strategy);
                
                var instance = builder.RegisterInstance(Activator.CreateInstance(typeof(TService), strategyInstance));

                regiterAs(instance);
            }
        }

        private static IEnumerable<Type> GetTypesAsignableTo(Type type)
        {
            return Assembly
                .GetAssembly(type)
                .GetTypes()
                .Where(x => type.IsAssignableFrom(x) && x != type);
        }
    }
}
