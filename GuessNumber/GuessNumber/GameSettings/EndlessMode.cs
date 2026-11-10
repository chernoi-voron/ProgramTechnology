using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public class EndlessMode :ISettings
    {

        private int _attempt;
        public int UsedAttempts { get; private set; } = 0;
        public bool CanAttempt()
        {
            return true;
        }
        public void SetAttempt()
        {
            UsedAttempts++;
        }
    }
}
