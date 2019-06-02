using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using TravelAccountant.Domain.Summaries;
using TravelAccountant.Infrastructure.Confirmations;
using TravelAccountant.Infrastructure.Summaries;

namespace TravelAccountant.Infrastructure
{
    internal class InversionOfControll : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisteConfirmationFileReaders(builder);
            RegisterySummaryFileWriters(builder);
        }

        private void RegisteConfirmationFileReaders(ContainerBuilder builder)
        {
            builder.RegisterType<ConfirmationEmlFileReader>().AsImplementedInterfaces();
            builder.RegisterType<ConfirmationPdfFileReader>().AsImplementedInterfaces();
        }

        private void RegisterySummaryFileWriters(ContainerBuilder builder)
        {
            const string COMPOSITION = "composition";
            var fileStratiegyTypes = GetTypesAsignableTo(typeof(IFileNameStrategy));

            foreach (var fileStrategyType in fileStratiegyTypes)
            {
                var fileStrategyInstance = (IFileNameStrategy)Activator.CreateInstance(fileStrategyType);
                builder.RegisterInstance(new SummarySheetFileWriter(fileStrategyInstance))
                    .Named<ISummarySheetService>(COMPOSITION);
            }

            builder.Register(c => 
                new SummarySheetFileWriterComposite(c.ResolveNamed<IEnumerable<ISummarySheetService>>(COMPOSITION)))
                .As<ISummarySheetService>();
        }

        private static IEnumerable<Type> GetTypesAsignableTo(Type type)
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => type.IsAssignableFrom(x) && x != type);
        }
    }
}
