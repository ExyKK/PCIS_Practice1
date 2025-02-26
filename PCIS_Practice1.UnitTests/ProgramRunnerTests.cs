using Moq;

namespace PCIS_Practice1.UnitTests
{
    [TestClass]
    public sealed class ProgramRunnerTests
    {
        private Mock<IUserInterface> _mockUi;
        private Mock<IFileReader> _mockFileReader;
        private ProgramRunner _programRunner;

        [TestInitialize]
        public void Setup()
        {
            _mockUi = new Mock<IUserInterface>();
            _mockFileReader = new Mock<IFileReader>();
            _programRunner = new ProgramRunner(_mockUi.Object, _mockFileReader.Object);
        }

        [TestMethod]
        public void ProcessFile_EmptyPathOrWord_ReturnsErrorMessage()
        {
            _programRunner.ProcessFile("", "word");

            _mockUi.Verify(ui => ui.WriteLine(It.Is<string>(msg => msg.Contains("Необходимо указать путь и слово для поиска"))), Times.Once);
        }

        [TestMethod]
        public void ProcessFile_FileDoesntExist_ReturnsErrorMessage()
        {
            _mockFileReader.Setup(fr => fr.FileExists(It.IsAny<string>())).Returns(false);

            _programRunner.ProcessFile("fakepath.txt", "word");

            _mockUi.Verify(ui => ui.WriteLine(It.Is<string>(msg => msg.Contains("Файл не найден"))), Times.Once);
        }

        [TestMethod]
        public void ProcessFile_ValidFile_ReturnsCorrectCount()
        {
            string fileContent = "Hello world! Hello everyone.";
            _mockFileReader.Setup(fr => fr.FileExists(It.IsAny<string>())).Returns(true);
            _mockFileReader.Setup(fr => fr.ReadFileContent(It.IsAny<string>())).Returns(fileContent);

            _programRunner.ProcessFile("fakepath.txt", "hello");

            _mockUi.Verify(ui => ui.WriteLine(It.Is<string>(msg => msg.Contains("Общее количество слов: 4\nКоличество повторений слова \"hello\": 2"))), Times.Once);
        }
    }
}
