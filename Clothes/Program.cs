namespace Clothes;

internal class Program
{
    static int WashOrWear = 1;
    static void Main(string[] args)
    {

        try
        {
            List<Clothing> wardrobe = new List<Clothing>
            {
                new Tshirt("#21324ts", "BigShort", 13000, "XL"), new Tshirt("TuTaTu"),
                new Shoes("#865sh", "Sneakers", 15000, 35.2), new Shoes("Not_Sneakers"),
                new Jacket("#175jt", "Cool_Parka", 32000, 67) ,new Jacket("Not_Cool_Parka")
            };
            foreach (Clothing w in wardrobe)
            {
                if (WashOrWear % 2 == 0) { w.Season = Season.Summer; }
                else {  w.Season = Season.Winter;}
                Console.WriteLine(w.ToString());
                switch (WashOrWear % 2)
                {
                    case (0):
                        {
                            w.Wear();
                            if (w is IWashable washable)
                            {
                                washable.Wash();
                            }
                            break;
                        }

                    case (1):
                        {
                            if (w is IWashable washable)
                            {
                                washable.Wash();
                            }
                            w.Wear();
                            break;

                        }
                }
                Console.WriteLine();
                ++WashOrWear;
            }

        }
        catch (Exception ex) { Console.WriteLine(ex); }
    }
}

