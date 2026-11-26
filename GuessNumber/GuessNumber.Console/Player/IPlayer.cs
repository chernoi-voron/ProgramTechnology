using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Player
{
    public interface IPlayer
    {
        public string Name { get; }

        public Guid ID { get; }
    }
}
