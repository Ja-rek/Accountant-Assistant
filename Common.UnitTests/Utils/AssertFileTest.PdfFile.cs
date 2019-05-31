using System;
using NUnit.Framework;
using Suckless.Asserts;
using Common.Utils;

namespace Common.UnitTests.Utils
{
    internal partial class AssertFileExtensionMethodsTest
    {
        [Test]
        public void PdfFile_WhenPathNotContainPdfExtension_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            var expectedMessage = 
                "The path in value: String contain '.exe' extension but should contain '.pdf'."; 
            
            var actualMessge = Assert.Throws<ArgumentException>(() => new Metadata<string>("App.exe", null)
                .PdfFile())
                .Message;

            Assert.AreEqual(expectedMessage, actualMessge);
        }

        [Test]
        public void PdfFile_WhenPathContainPdfExtension_ThenDoesNotThrowException()
        {
            new Metadata<string>("File.pdf", null).PdfFile();
        }
    }
}
