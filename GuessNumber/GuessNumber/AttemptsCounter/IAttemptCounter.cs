using GuessNumber.core.GameSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GuessNumber.core.AttemptsCounter
{
    public interface IAttemptCounter
    {
        public  ISettings Settings {  get; }
        int UsedAttempt { get; }
        bool CanAttempt();
        void SetAttempt();

        void ResetAttempt();    

        void SwitchMode(ISettings settings);

    }
}
