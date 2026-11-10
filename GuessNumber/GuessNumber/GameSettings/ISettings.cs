using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public interface ISettings
    {
        public int UsedAttempts{ get; }
        bool CanAttempt();
        void SetAttempt();
    }
}
