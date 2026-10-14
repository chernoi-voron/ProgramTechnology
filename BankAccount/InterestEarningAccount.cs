using Bank;
using BankAccount2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;
/// <summary>
/// Класс InterestEarningAccount наследующий BankAccount
/// </summary>
public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// Конструктор класса InterestEarningAccount 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialbalance"></param>
    public InterestEarningAccount(string name, decimal initialbalance)
        : base(name, initialbalance)
    { }
    // override позволяет в дочернем класс определить новую реализацию метода PerformMonthAndTransactions
    /// <summary>
    /// Метод дающий информацию о месячных транзакциях
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow,"Apply month interest");
        }
    }

}
