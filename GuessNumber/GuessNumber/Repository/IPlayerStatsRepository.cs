using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Repository
{
    public interface IPlayerStatsRepository
    {
        bool Save(Guid id,GlobalStatistics stats);

        GlobalStatistics? Get(Guid id);
    }
}
