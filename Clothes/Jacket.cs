using System;
namespace Clothes;

public class Jacket : Clothing, IWashable
{
    public bool is_wash { get; set; } = false;
    public bool is_worn { get; set; } = false;
    public int Insulation { get; set; }
    public bool IsWarm { get { if (insulation > 50) return true; return false; } }

    public Jacket(string sku, string name, decimal price, int insulation) : base(sku,name,price) 
    {
        if (insulation < 0) throw new ArgumentOutOfRangeException("The insulation must be more or equal zero ");
        Insulation = insulation;
    }
    public Jacket(string name) : base(name) 
    {
        Insulation = 0;
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
        return $"[Jacket] {Name}, {Price}, season:  {Season}\n" + $"price with discount: {PriceWithDiscount}";
    }
}
