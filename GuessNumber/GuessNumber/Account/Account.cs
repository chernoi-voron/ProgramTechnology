using GuessNumber.core.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Account
{
    public class Account
    {
        public Guid PlayerId { get; }
        public string Loggin { get; }


        public Account(IPlayer id,  string loggin)
        {
            if(loggin is null  || id is null) { throw new ArgumentNullException("loggin or id"); }
            Loggin = loggin;
            PlayerId = id.ID;
        }

    }
}
