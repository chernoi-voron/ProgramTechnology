using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Game
{
    public class GameWinEventArgs : EventArgs
    {
        public string Message { get; }
        public GameStatistic Statistic { get; }
        public bool Exodus { get; }
        public GameWinEventArgs(string message, GameStatistic stats, bool exodus)
        {
            Message = message;
             Statistic = stats;
            Exodus = exodus;
        }

    }
}
