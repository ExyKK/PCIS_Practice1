﻿namespace PCIS_Practice1
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
