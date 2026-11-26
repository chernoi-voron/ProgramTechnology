using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Stats
{
    public class GlobalStatistics 
    {
        public int Wins { get; private set; } = 0;

        public int Streak { get; private set; } = 0;

        public int BestStreak { get; private set; } = 0;
        public GlobalStatistics(int wins, int streak, int bestStrike)
        {
            if (wins < 0 || streak < 0 || bestStrike < 0) { throw new ArgumentOutOfRangeException("wins or streak or best streak must be more than zero"); }
            Wins = wins;
            Streak = streak;
            BestStreak = bestStrike;
        }

        public void Record(GameStatistic stats)
        {
            if (stats is null) throw new ArgumentNullException(nameof(stats));

            if (stats.IsWin)
            {
                Wins++;
                Streak++;
                if (BestStreak < Streak) { BestStreak = Streak; }
            }
            else
            {
                Streak = 0;
            }
        }
        public static GlobalStatistics operator +(GlobalStatistics stats1, GlobalStatistics stats2)
        {
            if (stats1 is null) throw new ArgumentNullException(nameof(stats1));
            if (stats2 is null) throw new ArgumentNullException(nameof(stats2));
            int wins = stats1.Wins + stats2.Wins;
            int streak = stats1.Streak + stats2.Streak;
            int bestStreak = Math.Max(stats1.BestStreak, stats2.BestStreak);
            return new GlobalStatistics(wins, streak, bestStreak);
        }
    }
}
