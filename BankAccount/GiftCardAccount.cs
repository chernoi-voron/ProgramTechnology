using BankAccount2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    // monthlyDeposit - параметр по умолчанию (принимает 0),
    // при создании new GiftCardAccount("Gigagu",1000); => monthlyDeposit = 0
    // new GiftCardAccount("Gigagu",1000,5000); => monthlyDeposit = 5000

    public GiftCardAccount(string name, decimal initialbalance ,decimal monthlyDeposit) : 
        base(name, initialbalance)
        => _monthlyDeposit = monthlyDeposit;

    public override void PerformMonthAndTransactions()
    {
        if(_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    // base.ToString() - вызов базовой реализации => реализация из класс BankAccount
    public override string ToString()
    {
        return base.ToString()+$"monthly deposit: {_monthlyDeposit}";
    }
}
