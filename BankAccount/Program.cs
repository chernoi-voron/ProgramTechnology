using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.Factories;
using BankAccounts.Core.Statements;
using BankAccounts.Core.Time;
using BankAccounts.Core.Accounts;

namespace BankAccounts.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new SystemClock();
            var factory =
                new AccountFactory(clock, new SequentialAccountNumberGenerator());
            var formatter = new TextStatementFormatter();



            var savings = factory.CreateInterestEarning("Yana", 10000m);
            savings.Deposit(100m, clock.Now, "asda");

            System.Console.WriteLine(formatter.Format(savings.Transactions));

            var deposit = factory.CreateDebitAccount("NotI", 1000m);
            deposit.Withdraw(750m, clock.Now, "Aboba");

            var credit = factory.CreateLineOfCredit("YesI", 550m);
            credit.Withdraw(110m, clock.Now, "Yes it's i");
            credit.Withdraw(500m, clock.Now, " ");
            List<BankAccount> accounts = new List<BankAccount>()
            {
                savings,
                deposit,
                credit
            };
             foreach (var account in accounts)
            {
                System.Console.WriteLine(formatter.Format(account.Transactions));
                System.Console.WriteLine();
                account.PerforMonthEndTransactions();
            }


            
        }
    }
}