using Bank;
using BankAccount2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialbalance)
        : base(name, initialbalance)
    { }
    // override позволяет в дочернем класс определить новую реализацию метода PerformMonthAndTransactions
    public override void PerformMonthAndTransactions()
    {
        if(Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow,"Apply month interest");
        }
    }

}
