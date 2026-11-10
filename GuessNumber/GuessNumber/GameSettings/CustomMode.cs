using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public class CustomMode : ISettings
    {
        private int _attempt;

        public bool CanAttempt()
        {
            return _attempt > 0;
        }
    }
}
