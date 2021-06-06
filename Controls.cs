using System;
using System.Threading;

namespace WestWorld
{
    public class Controls
    {

        public void ConvertConsoleKeyToInt()
        {
            inputInt1 = (int)inputKeyPress1.Key - 48;
            inputInt2 = (int)inputKeyPress2.Key - 48;
        }
        
        public void GetUserInput()
        {
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    do
                    {
                        Console.WriteLine("Press enter to resume");
                    }
                    while (Console.ReadKey().Key != ConsoleKey.Enter);
                }
            }
            Thread.Sleep(100);
        }

        public ConsoleKeyInfo inputKeyPress1;
        public ConsoleKeyInfo inputKeyPress2;
        public char inputChar1;
        public char inputChar2;
        public int inputInt1;
        public int inputInt2;
        public string inputString1;
        public string inputString2;
    }
}
