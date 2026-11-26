using GuessNumber.core.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Account
{
    public record PersonAccount(Guid Id, string Login, string Name);
}
