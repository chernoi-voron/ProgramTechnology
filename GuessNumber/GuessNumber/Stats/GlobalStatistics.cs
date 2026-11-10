using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Stats
{
    public class GlobalStatistics 
    {
        public int Wins { get; private set; }

        public int Strike { get; private set; }

        public int BestStrike {  get; private set; }

        GlobalStatistics(GameStatistic stats)
        {
            if(stats is null) throw new ArgumentNullException(nameof(stats));

            if(stats.LoseOrWin)
            {
                Wins++;
                Strike++;
                if(BestStrike < Strike) { BestStrike = Strike; }
            }
            else
            {
                Strike = 0;
            }
        }


    }
}
