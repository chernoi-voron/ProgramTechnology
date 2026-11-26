using GuessNumber.core.Player;
using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.PlayerAccount
{
    public class Player : IPlayer
    {
        public string Name { get; }

        public Guid ID { get; }


        public Player(string name, Guid Id)
        {
            if(Id == Guid.Empty) {throw new ArgumentNullException("id"); }
            if(name is null || name.Length < 2) {throw new ArgumentNullException("name");  }
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
