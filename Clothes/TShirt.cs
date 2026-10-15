using System;
using System.Drawing;
namespace Clothes;

public class Tshirt : Clothing, IWashable
{
    public bool is_wash { get; set; } = false;
    public bool is_worn { get; set; } = false;
    string Size { get; set; }
    public bool IsBigSize { get { if (Size == "XL" || Size == "XXL") return true; return false; } }

    public Tshirt(string sku, string name, decimal price, string size) : base(sku, name, price)
    {
        if (Size is null || Size.Length == 0) throw new ArgumentException("Incorrected set size");
        Size = size;
    }

    public Tshirt(string name) : base(name)
    {
        Size = "Unknown";
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
        return $"[Tshirt] {Name}, {Price}, season:  {Season}\n"+$"price with discount: {PriceWithDiscount}";
    }
}
