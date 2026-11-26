using GuessNumber.core.Account;
using GuessNumber.core.GameLogg;
using GuessNumber.core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.AuthService
{
    public class Authorization : IAuthorization,IRegistration
    {
        private IAccountRepository _rep {  get; }

        
        public Authorization( IAccountRepository rep)
        {
            if(rep is null) throw new ArgumentNullException(nameof(rep));
            _rep = rep;
        }
        public PersonAccount? Login(string login)
        {
            var Account =  _rep.ReadAccountFromRep(login);
            return Account;
        }
        public PersonAccount? Register(string login,string name)
        {
            var newAccount = new PersonAccount(Guid.NewGuid(), login, name);
            if (_rep.WriteAccountToRep(newAccount))
            {
                return newAccount;
            }
            return null;
        }
    }
}
