using System;
using System.Collections.Generic;
using System.Text;
using GuessNumber.core.Account;
using GuessNumber.core.Repository;

namespace GuessNumber.core.AuthService
{
    public interface IAuthorization
    {
        PersonAccount? Login(string login);
    }
}
