using GuessNumber.core.PlayerAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Account
{
    public class Account
    {
        public Guid PlayerId { get; }
        public string Loggin { get; }

        public string Password {  get; }

        public Account(Player id,  string loggin, string password)
        {
            if(loggin is null || password is null || id is null) { throw new ArgumentNullException("loggin or password or id"); }
            Loggin = loggin;
            Password = password;
            PlayerId = id.ID;
        }

    }
}
