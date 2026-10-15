namespace Clothes;
/// <summary>
/// Абстрактный класс для Одежды
/// </summary>
public abstract class Clothing
{
    /// <summary>
    /// Артикул для одежды
    /// </summary>
    private string _sku;
    /// <summary>
    /// Имя задаваемое для одежды
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Цена одежды
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Перечисление по умолчанию AllSeason 
    /// </summary>
    public Season Season { get; set; } = Season.AllSeason;
    /// <summary>
    /// Автоматическое свойство показывающее цену со скидкой
    /// </summary>
    public decimal PriceWithDiscount
    {
        get
        {
            return Price * 0.9m;
        }
    }
    /// <summary>
    /// Конструктор класс Clothing с тремя параметрами
    /// </summary>
    /// <param name="sku">Задаваемый артикул</param>
    /// <param name="name">Задаваемое имя</param>
    /// <param name="price">Задаваемая цена</param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    protected Clothing(string sku, string name, decimal price)
    {
        if (sku == null || sku.Length == 0) throw new ArgumentException("Incorrected set sku");
        if (name == null || name.Length == 0) throw new ArgumentException("Incorrected set name");
        if (price < 0) throw new ArgumentOutOfRangeException("The price must be more than zero");

        _sku = sku;
        Name = name;
        Price = price;
    }
    /// <summary>
    /// Конструктор класс Clothing с одним параметром
    /// </summary>
    /// <param name="name"></param>
    protected Clothing(string name) : this("N/A", name, 0) { }

    /// <summary>
    /// Метод о состоянии одежды(можно ли носить?)
    /// </summary>
    public abstract void Wear();
}