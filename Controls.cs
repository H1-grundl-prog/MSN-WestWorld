using System;
using System.Threading;

namespace WestWorld
{
    public class Controls
    {

        public void ParseConsoleKeyInfo()
        {
            // check if input is integer
            if(char.IsDigit((char)inputKeyPress.Key))
            {
                inputInt = (int)inputKeyPress.Key - 48;
            }
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

        public void Reset()
        {
            lastInputKeyPress = inputKeyPress;
            lastInputChar = inputChar;
            lastInputInt = inputInt;
            lastInputString = inputString;

            inputKeyPress = new ConsoleKeyInfo();
            inputChar = (char)0;
            inputInt = 0;
            inputString = "";
        }

        public void Update()
        {
            ParseConsoleKeyInfo();
        }

        public ConsoleKeyInfo inputKeyPress;
        public char inputChar;
        public int inputInt;
        public string inputString;

        public ConsoleKeyInfo lastInputKeyPress;
        public char lastInputChar;
        public int lastInputInt;
        public string lastInputString;
    }
}
