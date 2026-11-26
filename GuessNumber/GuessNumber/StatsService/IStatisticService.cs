using GuessNumber.core.Repository;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.StatsService
{
    public interface IStatisticService
    {
        public void RecordGame(Guid id, GameStatistic game);
        public string? PrintMyStats(Guid id);
    }
}
