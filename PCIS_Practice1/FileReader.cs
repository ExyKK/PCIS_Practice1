namespace PCIS_Practice1
{
    public class FileReader : IFileReader
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        
        public string ReadFileContent(string path)
        {
            return File.ReadAllText(path);
        }

        public static (int totalWords, int wordOccurences) CountWords(string text, string word)
        {
            string delim = " ,.:;?!()`";
            string[] wordsArray = text.Trim().Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int totalWordsCount = wordsArray.Length;
            int inputWordCount = wordsArray.Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));

            return (totalWordsCount, inputWordCount);
        }
    }
}
