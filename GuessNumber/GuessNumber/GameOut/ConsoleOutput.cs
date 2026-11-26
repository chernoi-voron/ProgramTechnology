using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameLogg
{
    public class ConsoleOutput :IGameOutput
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
