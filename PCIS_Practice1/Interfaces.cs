namespace PCIS_Practice1
{
    public interface IUserInterface
    {
        string? ReadLine();
        void WriteLine(string message);
    }
    
    public interface IFileReader
    {
        bool FileExists(string path);
        string ReadFileContent(string path);
    }
}
