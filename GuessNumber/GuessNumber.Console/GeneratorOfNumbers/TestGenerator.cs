using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GeneratorOfNumbers
{
    public class TestGenerator : IGenerate
    {
        public int Generate()
        {
            return 1;
        }
        public void SetRange(int min, int max)
        {
            return;
        }
    }
}
