using System;
using System.IO;
using Suckless.Asserts;

namespace Common.Utils
{
    public static class AssertFileExtensionMethods
    {
        public static ref readonly Metadata<string>  PdfFile(in this Metadata<string> metadata)
        {
            var path = Path.GetExtension(metadata.Value);

            const string PDF = ".pdf";

            if (metadata.Value != null & path != PDF)
            {
                throw FileException(metadata, path, PDF);
            }

            return ref metadata;
        }

        public static ref readonly Metadata<string>  EmlFile(in this Metadata<string> metadata)
        {
            var path = Path.GetExtension(metadata.Value);

            const string EML = ".eml";

            if (metadata.Value != null &  path != EML)
            {
                throw FileException(metadata, path, EML);
            }

            return ref metadata;
        }

        private static ArgumentException FileException(Metadata<string> metadata, string path, string expectedFile)
        {
            return new ArgumentException(
                $"The path in {metadata.Name} contain '{path}' extension but should contain '{expectedFile}'.");
            
        }
    }
}
