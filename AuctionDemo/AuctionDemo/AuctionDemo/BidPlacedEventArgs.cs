namespace AuctionDemo;

public sealed class BidPlacedEventArgs : EventArgs
{
    public string Title { get; }

    public string Bidder { get; }

    public decimal Amount { get; }
    public decimal? PreviousAmount { get; }

    public string? PreviousLeader { get; } 

    public BidPlacedEventArgs(string title, string bidder, decimal amount, decimal? previousAmount = null, string? previousLeader = null)
    {
        Title = title;
        Bidder = bidder;
        Amount = amount;
        PreviousAmount = previousAmount;
        PreviousLeader = previousLeader;

    }
}