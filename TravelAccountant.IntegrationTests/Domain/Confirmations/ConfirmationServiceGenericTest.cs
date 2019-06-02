using System.IO;
using System.Linq;
using NUnit.Framework;
using TravelAccountant.Domain.Confirmations;

namespace TravelAccountant.IntegrationTests.Domain.Confirmations
{
    internal abstract class ConfirmationServiceGenericTest<TConfirmation> where TConfirmation : Confirmation
    {
        const string DIRECTORY = "/home/jk/projects/AccountantAssistant/TravelAccountant."
            + "IntegrationTests/Domain/Confirmations/Files/";

        [Test]
        public void GetConfirmation_WhneConfirmationWithCorrectFileExtnsionExistOnDisk_ThenCanGetConfirmationWithCorrectValue()
        {
            var stubFilePath = DIRECTORY + $"file.{FileExtension}";
            var stubPathToConfirmation = new string[] { stubFilePath };

            var actualValue = ConfirmationService().GetConfirmations(stubPathToConfirmation).First();

            Assert.True(actualValue.Content.Contains("Tested text"), AssertMessage);
            Assert.True(actualValue.FilePath.Contains(stubFilePath), AssertMessage);
        }

        [Test]
        public void GetConfirmation_WhneDirectoryNotExist_ThenThrowsFileNotFoundException()
        {
            var stubIncorrectPath = new string[] { $"/home/wrongPath/file2.{FileExtension}" };

            Assert.Throws<FileNotFoundException>(() => 
                    ConfirmationService().GetConfirmations(stubIncorrectPath).First(), AssertMessage);
        }

        [Test]
        public void GetConfirmation_WhneFileNotExist_ThenThrowsFileNotFoundException()
        {
            var stubIncorrectPath = new string[] { DIRECTORY + $"file2.{FileExtension}" };

            Assert.Throws<FileNotFoundException>(() => 
                    ConfirmationService().GetConfirmations(stubIncorrectPath).First(), AssertMessage);
        }

        private static IConfirmationService<TConfirmation> ConfirmationService()
        {
            return ServiceLocator.Resolve<IConfirmationService<TConfirmation>>();
        }

        private string AssertMessage => $"Generic test of file extension {FileExtension}.";

        protected abstract string FileExtension { get; }
    }
}
