using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GeneratorNumbers
{
    public class GeneratorOfNumbers : IGenerator
    {
        private Random _rnd = new Random();
        private int _min;
        private int _max;
        GeneratorOfNumbers(int min = -100, int max = 100)
        {
            _min = min;
            _max = max+1;
        }
        public int Generate()
        {
            return _rnd.Next(_min,_max);
        }
    }
}
