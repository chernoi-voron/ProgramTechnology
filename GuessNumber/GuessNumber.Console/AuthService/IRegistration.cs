using GuessNumber.core.Account;
using GuessNumber.core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.AuthService
{
    public interface IRegistration
    {
        PersonAccount? Register(string login, string name);
    }
}
