using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts.Core.AccountNumbers
{
    public sealed class SequentialAccountNumberGenerator : IAccountNumberGenerator
    {
        private int _seed;
        public SequentialAccountNumberGenerator(int seed = 1234567890)
            => _seed = seed;

        public string Next()
        {
            return (_seed++).ToString();
        }
    }
}
