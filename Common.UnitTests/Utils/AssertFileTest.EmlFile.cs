using System;
using NUnit.Framework;
using Suckless.Asserts;
using Common.Utils;

namespace Common.UnitTests.Utils
{
    internal partial class AssertFileExtensionMethodsTest
    {
        [Test]
        public void EmlFile_WhenPathNotContainPdfExtension_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            var expectedMessage = 
                "The path in value: String contain '.exe' extension but should contain '.eml'."; 
            
            var actualMessge = Assert.Throws<ArgumentException>(() => new Metadata<string>("App.exe", null)
                .EmlFile())
                .Message;

            Assert.AreEqual(expectedMessage, actualMessge);
        }

        [Test]
        public void EmlFile_WhenPathContainPdfExtension_ThenDoesNotThrowException()
        {
            new Metadata<string>("File.eml", null).EmlFile();
        }
    }
}
