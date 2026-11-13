using GuessNumber.core.AttemptsCounter;
using GuessNumber.core.GeneratorOfNumbers;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Game
{
    public class GameSession : IGameSession
    {
        public IAttemptCounter attemptCounter { get; }

        public GameStatistic statistic { get; private set; }
        public int? guess { get; set; }

        public int secret { get; }

        public event Action<string>? NotifyCondition;

        public GameSession(IAttemptCounter attempt, int secret)
        {
            if (attempt is null) { throw new ArgumentNullException(nameof(attempt)); }
            attemptCounter = attempt;
            this.secret = secret;
        }
        public bool Guessing()
        {
            attemptCounter.SetAttempt();
            if (guess == secret)
            {
                NotifyCondition?.Invoke($"You guess a number {secret}");
                NotifyCondition?.Invoke($"Amount of attempts {attemptCounter.UsedAttempt}");
                statistic = new(attemptCounter.UsedAttempt, true);
                return true;
            }
            else if (guess < secret)
            {
                NotifyCondition?.Invoke($"Number bigger");
                if (!attemptCounter.CanAttempt())
                {
                    NotifyCondition?.Invoke($"The attempts have run out");

                    return true;
                }
                return false;
            }
            else
            {

                NotifyCondition?.Invoke($"Number smaller");
                if (!attemptCounter.CanAttempt())
                {
                    NotifyCondition?.Invoke($"The attempts have run out");
                    NotifyCondition?.Invoke($"Amount of attempts {attemptCounter.UsedAttempt}");
                    statistic = new(attemptCounter.UsedAttempt, false);
                    return true;
                }
                return false;
            }


        }
        public void RegisterEvent(Action<string> handler)
        {
            NotifyCondition += handler;
        }
    }
}
