
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GeneratorOfNumbers
{
    public class Generator : IGenerate
    {
        private Random rnd = new Random();
        private int _min;
        private int _max;
        Generator(int min=-100, int max=100)
        {
            _min = min;
            _max = max+1;
        }
         public int Generate()
        {
            return rnd.Next(_min, _max);
        }
    }
}
