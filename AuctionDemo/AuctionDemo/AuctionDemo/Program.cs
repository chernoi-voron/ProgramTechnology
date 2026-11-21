namespace AuctionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lot lot = new Lot("Pencel", 100m, 50m, DateTime.UtcNow.AddDays(1),1000);
            lot.BidPlaced += (obj, e) => Console.WriteLine($"[Log] Ставка: {obj} - {e.Amount}");

            lot.Repurchased += (obj, e) => Console.WriteLine($"[Log] Ставка: {obj} - {e}");
            //lot.PlaceBid("NotI", 10_000m);
            lot.BuyNow("YUT");


        }
    }
}
