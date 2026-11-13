using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GuessNumber.core.AttemptsCounter
{
    public interface IAttemptCounter
    {
        int UsedAttempt { get; }
        bool CanAttempt();
        void SetAttempt();

    }
}
