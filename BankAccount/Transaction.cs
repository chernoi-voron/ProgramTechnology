
namespace Bank;

internal record Transaction(decimal Amount, DateTime Date, string Note); // record - Состояние объектов этого класса нельзя изменить

//internal record Transaction
//{
//    public decimal Amount { get; }

//    public DateTime Date { get; }

//    public string Note { get; }
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    {
//        this.Amount = Amount;
//        this.Note = Note;
//        this.Date = Date;
//    }
//}
