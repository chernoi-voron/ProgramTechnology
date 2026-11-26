using GuessNumber.core.GameSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.AttemptsCounter
{
    public class Attempt : IAttemptCounter
    {
        public ISettings Settings { get; private set; }
        public int UsedAttempt { get; private set; } = 0;
        public Attempt(ISettings settings)
        {
            if (settings is null) { throw new ArgumentNullException(nameof(settings)); }
            Settings = settings;
        }
        public bool CanAttempt()
        {
            if (Settings.MaxAttempts is null) { return true; }
            return Settings.MaxAttempts - UsedAttempt > 0;
        }
        public void SetAttempt()
        {

            UsedAttempt += Settings.Cost;
        }
        public void ResetAttempt()
        {
            UsedAttempt = 0;
        }
        public void SwitchMode(ISettings settings)
        {
            if (settings is null) { throw new ArgumentNullException(nameof(settings)); }
            Settings = settings;
        }
    }
}
    
