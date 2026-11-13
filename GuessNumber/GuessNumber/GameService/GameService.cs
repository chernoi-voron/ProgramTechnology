using GuessNumber.core.Game;
using GuessNumber.core.GameLogg;
using GuessNumber.core.Player;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameService
{
    public class GameService
    {
        private IGameOutput _gameOutput;
        private IGameInput _gameInput;
        public readonly IPlayer _player;
        public readonly IGameSession _session;

        public GameService(IPlayer player, IGameSession session, IGameOutput gameOutput, IGameInput gameInput)
        {
            if (player is null) { throw new ArgumentNullException(nameof(player)); }
            if (session is null) { throw new ArgumentNullException(nameof(session)); }
            if (gameOutput is null) { throw new ArgumentNullException(nameof(gameOutput)); }
            if (gameInput is null) { throw new ArgumentNullException(nameof(gameInput)); }
            _player = player;
            _session = session;
            _gameOutput = gameOutput;
            _gameInput = gameInput;
        }
        public GameStatistic Game()
        {
            _session.RegisterEvent(_gameOutput.Print);
            do
            {
                _session.guess = _gameInput.Read();
            } while (!_session.Guessing());
            return _session.statistic;

        }
        public void Menu()
        {
            _gameOutput.Print("Choose a menu item:\n 1- Start the Game 2 - Exit from game");
            while (true)
            {
                switch (_gameInput.Read())
                {
                    case 1:
                        {
                            Game();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    default:
                        {
                            _gameOutput.Print("Incorrect menu item");
                            break;
                        }
                }


            }
        }
    }
}
