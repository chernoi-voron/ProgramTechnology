namespace Clothes;

abstract class Clothing
{
    private string _sku;
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Season Season { get; set; } = Season.AllSeason;

    public decimal PriceWithDiscount
    {
        get
        {
            return Price * 0.9m;
        }
    }

    protected Clothing(string sku, string name, decimal price)
    {
        if (sku == null || sku.Length == 0) throw new ArgumentException("Incorrected set sku");
        if (name == null || name.Length == 0) throw new ArgumentException("Incorrected set name");
        if (price < 0) throw new ArgumentOutOfRangeException("The price must be more than zero");

        _sku = sku;
        Name = name;
        Price = price;
    }
    protected Clothing(string name) : this("N/A", name, 0) { }

    public abstract void Wear();
}