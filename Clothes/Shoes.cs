using System;
namespace Clothes;

public class Shoes : Clothing, IWashable
{
    public bool is_wash { get; set; } = false;
    public bool is_worn { get; set; } = false;
    public double SoleThickness { get; set; };
    public bool IsSporty { get { if(SoleThickness > 25 &  SoleThickness < 40) return true; return false; } }

    public Shoes(string sku, string name, decimal price, double soleThickness) : base(sku,name,price) 
    {
        if(soleThickness < 0) throw new ArgumentOutOfRangeException("SoleThickness must be more or equal zero")
    }
    public Shoes(string name) : base(name)
    {
        SoleThickness = 0;
    }

    public override void Wear()
    {
        if (is_wash is true)
        {
            Console.WriteLine($"{Name} cannot be worn");
            return;
        }
        is_worn = true;
        Console.WriteLine($"{Name} worn");

    }
    public override void Wash()
    {
        if (is_worn is true)
        {
            Console.WriteLine($"{Name} cannot be washed");
            return;
        }
        is_wash = true;
        Console.WriteLine($"{Name} washed");
    }
    public override string ToString()
    {
        return $"[Shoes] {Name}, {Price}, season:  {Season}\n" + $"price with discount: {PriceWithDiscount}";
    }
}
