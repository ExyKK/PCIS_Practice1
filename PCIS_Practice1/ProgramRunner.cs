namespace PCIS_Practice1
{
    public class ProgramRunner
    {
        private readonly IUserInterface _ui;
        private readonly IFileReader _fileReader;

        public ProgramRunner(IUserInterface ui, IFileReader fileReader)
        {
            _ui = ui;
            _fileReader = fileReader;
        }

        public void Run()
        {
            _ui.WriteLine("Укажите полный путь к текстовому файлу:");
            string? path = _ui.ReadLine()?.Trim();
            _ui.WriteLine("Задайте слово для поиска:");
            string? word = _ui.ReadLine()?.Trim();

            ProcessFile(path, word);
        }

        public void ProcessFile(string? path, string? word)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(word))
            {
                _ui.WriteLine("\n! Необходимо указать путь и слово для поиска !");
                return;
            }
            if (!_fileReader.FileExists(path))
            {
                _ui.WriteLine("\n! Файл не найден !");
                return;
            }

            try
            {
                string fileContent = _fileReader.ReadFileContent(path);
                var (totalWords, wordOccurrences) = FileReader.CountWords(fileContent, word);

                _ui.WriteLine($"\nОбщее количество слов: {totalWords}\nКоличество повторений слова \"{word}\": {wordOccurrences}");
            }
            catch (IOException e)
            {
                _ui.WriteLine($"\n! Ошибка чтения файла. {e.Message} !");
            }
            catch (Exception e)
            {
                _ui.WriteLine($"\n! Непредвиденная ошибка. {e.Message} !");
            }
        }
    }
}
