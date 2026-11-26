using GuessNumber.core.Repository;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.StatsService
{
    public class StatisticService : IStatisticService
    {
        private IPlayerStatsRepository _statsRepository;
        public StatisticService(IPlayerStatsRepository statsRepository)
        {
            if(statsRepository is null) { throw new ArgumentNullException(nameof(statsRepository)); }
            _statsRepository = statsRepository;
        }
        public void RecordGame(Guid id, GameStatistic game)
        {
            if(game is null) { throw new ArgumentNullException(nameof(game)); }
            if(_statsRepository.ReadStatsPlayerFromRep(id) is null)
            { 
                _statsRepository.WriteStatsPlayerToRep(id,new GlobalStatistics(0,0,0));
                var newgoodstats = _statsRepository.ReadStatsPlayerFromRep(id);
                newgoodstats.Record(game);
                _statsRepository.WriteStatsPlayerToRep(id, newgoodstats);
            }
            else
            {
                var existingStats = _statsRepository.ReadStatsPlayerFromRep(id);
                existingStats.Record(game);
                _statsRepository.WriteStatsPlayerToRep(id, existingStats);
            }

        }
        public string? PrintMyStats(Guid id)
        {
            var tempstat = _statsRepository.ReadStatsPlayerFromRep(id);
            if (tempstat is null) return null;
            return $"Wins: {tempstat.Wins} Strike: {tempstat.Streak} BestStreak: {tempstat.BestStreak}";
        }
    }
}
