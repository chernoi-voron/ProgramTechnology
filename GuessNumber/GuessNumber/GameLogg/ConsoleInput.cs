using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameLogg
{
    public class ConsoleInput : IGameInput
    {
        public int Read()
        {
            while (true)
            {
                Console.WriteLine("Enter a number");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                Console.WriteLine("That is not number");
            }
               
        }
    }
}
