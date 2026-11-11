using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public class CustomMode : ISettings
    {
        public int? MaxAttempts {  get; }
        public int Cost { get; }

        public CustomMode(int maxAttempt, int cost)
        {
            if (maxAttempt <= 0  ) { throw new ArgumentOutOfRangeException("The attempts must be positive"); }
            if (cost <= 0 ) { throw new ArgumentOutOfRangeException("The cost of attempts must be positive"); }
            MaxAttempts = maxAttempt;
            Cost = cost;

        }

    }
}
