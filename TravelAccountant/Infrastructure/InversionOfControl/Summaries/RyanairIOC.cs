using System.Reflection;
using Autofac;
using Common.Utils;
using TravelAccountant.Domain.Summaries.Ryanair;

namespace TravelAccountant.Infrastructure.InversionOfControl.Summaries
{
    public class RyanairIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterInstancesWithAllStratiegies<ConfirmationTemplateSpecyfication, ICurrencyPolicy>(
                x => x.AsImplementedInterfaces());

            builder.RegisterInstancesWithAllStratiegies<BookingSummaryService, ICurrencyPolicy>(
                x => x.AsImplementedInterfaces());
        }
    }
}
