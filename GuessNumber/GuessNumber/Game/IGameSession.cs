using GuessNumber.core.AttemptsCounter;
using GuessNumber.core.GeneratorOfNumbers;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Game
{
    public interface IGameSession
    {
        IAttemptCounter attemptCounter { get; }

        GameStatistic statistic { get; }
        int? guess { get; set; }

        int secret {  get; }

        void RegisterEvent(Action<string> handler);
        bool Guessing();
    }
}
