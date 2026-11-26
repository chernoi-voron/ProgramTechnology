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

        private event Action<string>? NotifyCondition;

        public event EventHandler<GameWinEventArgs>? GameExodus;

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
                statistic = new(attemptCounter.UsedAttempt, true);
                attemptCounter.ResetAttempt();
                OnGameExodus(new GameWinEventArgs($"You guess a number {secret}", statistic ,true));
                return true;
            }
            else if (guess < secret)
            {
                NotifyCondition?.Invoke($"The guessed number is greater.");
                if (!attemptCounter.CanAttempt())
                {
                    statistic = new(attemptCounter.UsedAttempt, false);
                    attemptCounter.ResetAttempt();
                    OnGameExodus(new GameWinEventArgs($"The attempts have run out", statistic, false));
                    return true;
                }
                return false;
            }
            else
            {

                NotifyCondition?.Invoke($"The guessed number is less.");
                if (!attemptCounter.CanAttempt())
                {
                    statistic = new(attemptCounter.UsedAttempt, false);
                    attemptCounter.ResetAttempt();
                    OnGameExodus(new GameWinEventArgs($"The attempts have run out", statistic, false));

                    return true;
                }
                return false;
            }


        }
        public void RegisterEventNotify(Action<string> handler)
        {
            NotifyCondition += handler;
        }
        public void UnregisterEventNotify(Action<string> handler)
        {
            NotifyCondition -= handler;
        }
        private void OnGameExodus(GameWinEventArgs e) => GameExodus?.Invoke(this, e);
    }
}
