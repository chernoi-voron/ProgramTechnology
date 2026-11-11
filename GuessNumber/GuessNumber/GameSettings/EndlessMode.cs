using GuessNumber.core.AttemptsCounter;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public class EndlessMode :ISettings
    {
        public int? MaxAttempts { get; } = null;
        public int Cost { get; } = 1;
    }
}
