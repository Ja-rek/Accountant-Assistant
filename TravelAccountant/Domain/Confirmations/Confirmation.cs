using static Suckless.Asserts.Assertions;

namespace TravelAccountant.Domain.Confirmations
{
    public abstract class Confirmation
    {
        public Confirmation(string filePath, string content)
        {
            Assert(content).NotEmpty();

            FilePath = filePath;
            Content = content;
        }

        public string FilePath { get; }
        public string Content { get; }
    }
}
