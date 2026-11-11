using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Stats
{
    public class GlobalStatistics 
    {
        public int Wins { get; private set; } = 0;

        public int Streak { get; private set; } = 0;

        public int BestStrike { get; private set; } = 0;

        public void Record(GameStatistic stats)
        {
            if (stats is null) throw new ArgumentNullException(nameof(stats));

            if (stats.LoseOrWin)
            {
                Wins++;
                Streak++;
                if (BestStrike < Streak) { BestStrike = Streak; }
            }
            else
            {
                Streak = 0;
            }
        }

    }
}
