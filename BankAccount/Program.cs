using System.Security.Principal;

namespace BankAccount
{
    internal class Program
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
            account.listofTransaction();
            

            try
            {
                account2.MakeWithdrawal(1000000000, DateTime.UtcNow, "ohohoho");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            account2.listofTransaction();

        }
    }

}
