using System.Reflection;
using Autofac;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.Infrastructure.InversionOfControl
{
    public class ConfirmationsIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => x.Name.EndsWith("FileReader"))
                .AsImplementedInterfaces();
        }
    }
}
