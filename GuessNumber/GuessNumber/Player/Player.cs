using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.PlayerAccount
{
    public class Player
    {
        public string Name { get; }

        public Guid ID { get; }
        public GlobalStatistics Stats { get; } = new();

        public Player(string name, Guid Id)
        {
            if(Id == Guid.Empty) {throw new ArgumentNullException("id"); }
            if(name is null || name.Length < 3) {throw new ArgumentNullException("name");  }
            Name = name;
            ID = Id;
        }

        public Player(string name)
        {
            Name = name;
            ID = Guid.NewGuid();
        }
    }
}
