using Bank;
using System.Security.Principal;

namespace BankAccount2
{
    public class Program
    {
        static void Main(string[] args)
        {



            BankAccount account = new BankAccount("Joe", 100000);
            BankAccount account2 = new BankAccount("Dou", 1241456);
            
            Console.WriteLine($"account {account.Balance} #{account.Number} {account.Owner}");
            Console.WriteLine($"account {account2.Balance} #{account2.Number} {account2.Owner}");

            account.MakeDeposit(2000000, DateTime.UtcNow, ":)");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(200, DateTime.UtcNow, ":(");
            Console.WriteLine(account.Balance);
            

            try
            {
                account2.MakeWithdrawal(1000000000, DateTime.UtcNow, "ohohoho");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            
            InterestEarningAccount interestEarning = new InterestEarningAccount("Ugagii", 12323m);
            interestEarning.MakeDeposit(1000m, DateTime.UtcNow, "Da da");
            interestEarning.MakeWithdrawal(10m, DateTime.UtcNow, "No no");
            interestEarning.PerformMonthAndTransactions();

            Console.WriteLine(interestEarning);// == Console.WriteLine(interestEarning.ToString());
            Console.WriteLine(interestEarning.GetAccountHistory());

            GiftCardAccount cardAccount = new("No me", 1000m,5000m);
            cardAccount.MakeDeposit(100m, DateTime.UtcNow, " (* *)");
            cardAccount.MakeWithdrawal(10m, DateTime.UtcNow, " (&_ &_)");
            cardAccount.PerformMonthAndTransactions();

            Console.WriteLine(cardAccount);
            Console.WriteLine(cardAccount.GetAccountHistory);


        }
    }

}
