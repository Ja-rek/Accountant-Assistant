using Autofac;
using TravelAccountant.Infrastructure.Summaries;

namespace TravelAccountant.IntegrationTests
{
    internal static class ServiceLocator
    {
        public static TService Resolve<TService>()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyModules(typeof(IFileNameStrategy).Assembly);

            return builder.Build().BeginLifetimeScope().Resolve<TService>();
        }
    }
}
