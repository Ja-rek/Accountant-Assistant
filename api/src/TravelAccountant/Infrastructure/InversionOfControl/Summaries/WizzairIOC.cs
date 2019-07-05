using System.Reflection;
using Autofac;
using Common.Utils;
using TravelAccountant.Domain.Confirmations;
using TravelAccountant.Domain.Summaries;
using TravelAccountant.Domain.Summaries.Wizzair;

namespace TravelAccountant.Infrastructure.InversionOfControl.Summaries
{
    public class WizzairIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterInstancesWithAllStratiegies<ConfirmationTemplateSpecyfication, ICurrencyPolicy>(
                x => x.AsImplementedInterfaces());

            builder.RegisterInstancesWithAllStratiegies<InvoiceSummaryService, ICurrencyPolicy>(
                x => x.AsImplementedInterfaces());

            builder.RegisterType<SummaryService<ConfirmationPdf>>().Keyed<ISummaryService>(".pdf");
        }
    }
}
