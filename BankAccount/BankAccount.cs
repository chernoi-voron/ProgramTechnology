

using Bank;
using System.Text;

namespace BankAccount2;

// BankAccount - потомок класс object => можно переопределить 
// виртуальные методы находящиеся в object
public class BankAccount
{
    private readonly decimal _minimumbalance;
    static private int s_accountNumberSeed = 1000000000;
    public string Number { get; }
    public string Owner { get; private set; }

    public decimal Balance 
    { 
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    public BankAccount(string owner, decimal initialBalance): this(owner, initialBalance, 0) { }
    public BankAccount(string owner, decimal initialBalance, decimal minimumbalance)
    {
       
        Owner = owner; //this.Owner = name
        _minimumbalance = minimumbalance;
        if (initialBalance < 0) 
        {
            MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
        }
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposit(decimal  amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount,date, note);
        _allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Transaction? overdraftTransaction = CheckWithDrawalLimit(Balance- amount < _minimumbalance);
        Transaction? withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);

        if (overdraftTransaction != null) 
        {
            _allTransactions.Add(overdraftTransaction);       
        }
    }

    protected Transaction? CheckWithDrawalLimit(bool v)
    {
        if(v)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
        }
        return default;
    }

    //public void listofTransaction()
    //{
    //    foreach (var listoftrans in _allTransactions)
    //    {
    //        Console.WriteLine(listoftrans);
    //    }
    //}
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }


    //Ключевое слово virtual позволяет в дочернем классе
    //предоставить другую реализацию
    //метода PerformMonthAndTransactions
    public virtual void PerformMonthAndTransactions()
    {

    }

    // переопределяем метод, который унаследовали от object
    // этот метод должен возвращать строку с состоянием объекта
    //public override string ToString()
    //{
    //    return $"Type:{GetType().Name} Owner: {Owner}\tNumber of account:{Number}";
    //}
    public override string ToString()
    
       => $"Type: {GetType().Name}\t Owner: {Owner}\tNumber of account:{Number}";
}
