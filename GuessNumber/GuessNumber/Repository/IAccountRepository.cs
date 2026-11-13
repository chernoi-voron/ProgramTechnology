using GuessNumber.core.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Repository
{
    public interface IAccountRepository
    {

        bool Write(PersonAccount account);

        PersonAccount? Read(string Login);
    }
}
