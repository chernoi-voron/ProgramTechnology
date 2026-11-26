using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public class RealMode : ISettings
    {
        public string NameOfMode { get; } = "RealMode";
        public int? MaxAttempts { get; } = 20;
        public int Cost { get; } = 1;
    }
}
