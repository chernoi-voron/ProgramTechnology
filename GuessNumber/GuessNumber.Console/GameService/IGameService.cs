using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameService
{
    public interface IGameService
    {
        public GameStatistic Game();
        public void Menu();
    }
}
