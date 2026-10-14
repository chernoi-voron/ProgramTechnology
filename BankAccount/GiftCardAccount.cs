using BankAccount2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;
/// <summary>
/// Класс Подарочной карты наследуещий BankAccount
/// </summary>
public class GiftCardAccount : BankAccount
{
    /// <summary>
    /// Депозит в месяц по умолчанию
    /// </summary>
    private readonly decimal _monthlyDeposit = 0m;

    // monthlyDeposit - параметр по умолчанию (принимает 0),
    // при создании new GiftCardAccount("Gigagu",1000); => monthlyDeposit = 0
    // new GiftCardAccount("Gigagu",1000,5000); => monthlyDeposit = 5000
    /// <summary>
    /// Конструкор GiftCardAccount принимающий 3 параметра
    /// </summary>
    /// <param name="name"></param>
    /// <param name="initialbalance"></param>
    /// <param name="monthlyDeposit"></param>
    public GiftCardAccount(string name, decimal initialbalance ,decimal monthlyDeposit) : 
        base(name, initialbalance)
        => _monthlyDeposit = monthlyDeposit;
    /// <summary>
    /// Метод добавляющий проценты по счёту
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if(_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }
    // base.ToString() - вызов базовой реализации => реализация из класс BankAccount
    /// <summary>
    ///  Метод предоставляющий информацию о типе,владельце и номере аккаунта,ежемесячный депозит
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return base.ToString()+$"monthly deposit: {_monthlyDeposit}";
    }
}
