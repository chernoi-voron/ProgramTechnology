using GuessNumber.core.Repository;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.StatsService
{
    public class StatisticService
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
            if(_statsRepository.Get(id) is null)
            { 
                _statsRepository.Save(id,new GlobalStatistics(0,0,0));
                var newgoodstats = _statsRepository.Get(id);
                newgoodstats.Record(game);
                _statsRepository.Save(id, newgoodstats);
            }
            else
            {
                _statsRepository.Get(id).Record(game);
                _statsRepository.Save(id, _statsRepository.Get(id));

            }

        }
        public string PrintMyStatic(Guid id)
        {
            var tempstat = _statsRepository.Get(id);
            return $"Wins: {tempstat.Wins} Strike: {tempstat.Streak} BestStrike: {tempstat.BestStrike}";
        }
    }
}
