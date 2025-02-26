namespace PCIS_Practice1.UnitTests
{
    [TestClass]
    public sealed class FileReaderTests
    {
        [TestMethod]
        public void CountWords_InputWithOccurrences_ReturnsExpectedCount()
        {
            string text = "Hello world! Hello again. Test hello.";
            string searchWord = "hello";

            var (totalWords, wordOccurrences) = FileReader.CountWords(text, searchWord);

            Assert.AreEqual(6, totalWords);
            Assert.AreEqual(3, wordOccurrences);
        }

        [TestMethod]
        public void CountWords_InputWithNoOccurrences_ReturnsTotalAndZero()
        {
            string text = "Sample text? Very sample text.";
            string word = "hello";

            var (totalWords, wordOccurrences) = FileReader.CountWords(text, word);

            Assert.AreEqual(5, totalWords);
            Assert.AreEqual(0, wordOccurrences);
        }
    }
}
