using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GuessNumber.core.AttemptsCounter
{
    public interface IAttemptCounter
    {
        bool CanAttempt();
        void SetAttempt();

    }
}
