using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Repository
{
    public interface IPlayerStatsRepository
    {
        bool WriteStatsPlayerToRep(Guid id,GlobalStatistics stats);

        GlobalStatistics? ReadStatsPlayerFromRep(Guid id);
    }
}
