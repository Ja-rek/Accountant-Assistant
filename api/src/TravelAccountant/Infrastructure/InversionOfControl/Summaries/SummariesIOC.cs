using System;
using System.Collections.Generic;
using Autofac;
using Common.Utils;
using TravelAccountant.Application.Summaries;
using TravelAccountant.Domain.Confirmations;
using TravelAccountant.Domain.Summaries;
using TravelAccountant.Infrastructure.Summaries;

namespace TravelAccountant.Infrastructure.InversionOfControl.Summaries
{
    public class SummariesIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string COMPOSITION = "composition";

            builder.RegisterInstancesWithAllStratiegies<SummarySheetFileWriter, IFileNameStrategy>(x =>
                x.Named<ISummarySheetService>(COMPOSITION));

            builder.Register(c => Activator.CreateInstance(typeof(SummarySheetFileWriterComposite), 
                c.ResolveNamed<IEnumerable<ISummarySheetService>>(COMPOSITION)))
                .As<ISummarySheetService>();

            builder.RegisterGeneric(typeof(IncorrectConfirmationTemplateSpecyfication<>)).AsSelf();

            builder.RegisterType<Dictionary<string, ISummaryService>>()
                .As<IReadOnlyDictionary<string, ISummaryService>>();

            builder.RegisterType<SummaryService<ConfirmationEmail>>().Keyed<ISummaryService>(".eml");
            builder.RegisterType<SummaryService<ConfirmationPdf>>().Keyed<ISummaryService>(".pdf");

            builder.Register(ctx => 
                new SummaryApplicationService(
                    new SummaryServiceComposite(ctx.Resolve<IDictionary<string, ISummaryService>>()), 
                    ctx.Resolve<ISummarySheetService>())).AsSelf();
        }
    }
}
