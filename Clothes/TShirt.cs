using System;
using System.Drawing;
namespace Clothes;

/
public class Tshirt : Clothing, IWashable
{
    public bool Is_wash { get; set; } = false;
    public bool Is_worn { get; set; } = false;
    public string Size { get; set; }
    public bool IsBigSize { get { if (Size == "XL" || Size == "XXL") return true; return false; } }

    public Tshirt(string sku, string name, decimal price, string size) : base(sku, name, price)
    {
        if (size is null || size.Length == 0) throw new ArgumentException("Incorrected set size");
        Size = size;
    }

    public Tshirt(string name) : base(name)
    {
        Size = "Unknown";
    }

    public override void Wear()
    {
        if (Is_wash is true)
        {
            Console.WriteLine($"{Name} cannot be worn");
            return;
        }
        Is_worn = true;
        Console.WriteLine($"{Name} worn");

    }
    public void Wash()
    {
        if (Is_worn is true)
        {
            Console.WriteLine($"{Name} cannot be washed");
            return;
        }
        Is_wash = true;
        Console.WriteLine($"{Name} washed");
    }
    public override string ToString()
    {
        return $"[Tshirt] {Name}, {Price}, season:  {Season}\n"+$"price with discount: {PriceWithDiscount}";
    }
}
