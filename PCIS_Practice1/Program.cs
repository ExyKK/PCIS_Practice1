namespace PCIS_Practice1
{
    internal class Program
    {
        static void Main()
        {
            IUserInterface ui = new ConsoleUserInterface();
            IFileReader fileReader = new FileReader();
            ProgramRunner programRunner = new(ui, fileReader);
            programRunner.Run();
        }
    }
}
