using Autofac;
using NUnit.Framework;
using Common.Utils;
using Common.UnitTests.Utils.Fakes;
using System.Collections.Generic;
using System.Linq;

namespace Common.UnitTests.Utils.AutofacExtensionMethods
{
    internal class AutofacExtensionMethodsTest
    {
        [Test]
        public void RegisterInstancesWithAllStratiegies_WhenRegistedTheInstances_ThenCanResolveCorrectCountOfThoseInstances()
        {
            var servicesWithAllStrategies = Resolve<IEnumerable<ServiceFake>>();

            Assert.True(servicesWithAllStrategies.Count() == 2);
        }

        public static TService Resolve<TService>()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterInstancesWithAllStratiegies<ServiceFake, IStrategyFake>(x => x.AsSelf());

            return builder.Build().BeginLifetimeScope().Resolve<TService>();
        }
    }
}
