using BankAccounts.Core.Transactions;
using System.Transactions;

namespace BankAccounts.Core.Accounts;

// ISP: клиенты зависят только от того, что им реально нужно
public interface IAccountStatement
{
    IReadOnlyList<Transactions.Transaction> Transactions { get; }
}