using Autofac;
using TravelAccountant.Infrastructure.Confirmations;

namespace TravelAccountant.Infrastructure
{
    internal class InversionOfControll : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisteConfirmationFileReaders(builder);
        }

        private void RegisteConfirmationFileReaders(ContainerBuilder builder)
        {
            builder.RegisterType<ConfirmationEmlFileReader>().AsImplementedInterfaces();
            builder.RegisterType<ConfirmationPdfFileReader>().AsImplementedInterfaces();
        }
    }
}
