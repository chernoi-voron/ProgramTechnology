using System;
using System.Drawing;
namespace Clothes;

/// <summary>
/// 
/// </summary>
public class Tshirt : Clothing, IWashable
{
    /// <summary>
    /// Свойство проверяющее в находится ли одежда в стирке
    /// </summary>
    public bool Is_wash { get; set; } = false;
    /// <summary>
    /// Свойство содержащее информацию в находится ли одежда в носке
    /// </summary>
    public bool Is_worn { get; set; } = false;
    /// <summary>
    /// Cвойство о размере одежды 
    /// </summary>
    public string Size { get; set; }
    /// <summary>
    /// Свойство проверяющее большая ли одежда
    /// </summary>
    public bool IsBigSize { get { if (Size == "XL" || Size == "XXL") return true; return false; } }
    /// <summary>
    /// Конструктор Tshirt с четырьмя параметрами
    /// </summary>
    /// <param name="sku">Задаваемый артикул</param>
    /// <param name="name">Задаваемое имя</param>
    /// <param name="price">Задаваемая цена</param>
    /// <param name="size">Задаваемая толщина подошвы</param>
    /// <exception cref="ArgumentException"></exception>

    public Tshirt(string sku, string name, decimal price, string size) : base(sku, name, price)
    {
        if (size is null || size.Length == 0) throw new ArgumentException("Incorrected set size");
        Size = size;
    }
    /// <summary>
    /// Конструктор Tshirt с одним параметром
    /// </summary>
    /// <param name="name">Задаваемое имя</param>
    public Tshirt(string name) : base(name)
    {
        Size = "Unknown";
    }
    /// <summary>
    /// Переопределённый метод Wear одевающий одежду если она не в стирке
    /// </summary>
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
    /// <summary>
    /// Переопределённый метод Wash стирающий одежду если она не в носке
    /// </summary>
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
    /// <summary>
    /// Переопредлённый метод ToString Возвращающий информацию о футболках
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[Tshirt] {Name}, {Price}, season:  {Season}\n"+$"price with discount: {PriceWithDiscount}";
    }
}
