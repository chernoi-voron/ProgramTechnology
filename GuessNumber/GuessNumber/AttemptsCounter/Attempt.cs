using GuessNumber.core.GameSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.AttemptsCounter
{
    public class Attempt :IAttemptCounter
    {
        private ISettings _settings;
        public int UsedAttempt { get; private set; } = 0;
        public Attempt(ISettings settings)
        {
            if(settings is null) {throw new ArgumentNullException(nameof(settings)); }
            _settings = settings;
        }
        public bool CanAttempt()
        {
            if (_settings.MaxAttempts is null) { return true; }
            return _settings.MaxAttempts > UsedAttempt;
        }
        public void SetAttempt()
        {

            UsedAttempt += _settings.Cost;
        }
    }   
}
