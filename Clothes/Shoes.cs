using System;
namespace Clothes;
/// <summary>
/// 
/// </summary>
public class Shoes : Clothing, IWashable
{
    /// <summary>
    /// Свойство содержащее информацию находится ли одежда в стирке
    /// </summary>
    public bool Is_wash { get; set; } = false;
    /// <summary>
    /// Свойство содержащее информацию в находится ли одежда в носке
    /// </summary>
    public bool Is_worn { get; set; } = false;
    /// <summary>
    /// Свойство о толщину подошвы
    /// </summary>
    public double SoleThickness { get; set; }
    /// <summary>
    /// Вычисляемое свойство проверяющее спортивная ли обувь
    /// </summary>
    public bool IsSporty { get { if(SoleThickness > 25 &  SoleThickness < 40) return true; return false; } }

    /// <summary>
    /// Конструктор Shoes с четырьмя параметрами
    /// </summary>
    /// <param name="sku">Задаваемый артикул</param>
    /// <param name="name">Задаваемое имя</param>
    /// <param name="price">Задаваемая цена</param>
    /// <param name="soleThickness">Задаваемая толщина подошвы</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Shoes(string sku, string name, decimal price, double soleThickness) : base(sku,name,price) 
    {
        if (soleThickness < 0) throw new ArgumentOutOfRangeException("SoleThickness must be more or equal zero");
    }
    /// <summary>
    /// Конструктор Jacket с одним параметром
    /// </summary>
    /// <param name="name">Задаваемое имя</param>
    public Shoes(string name) : base(name)
    {
        SoleThickness = 0;
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
    ///  Переопределённый метод Wash стирающий одежду если она не в носке
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
    /// Переопредлённый метод ToString Возвращающий информацию о ботинках
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[Shoes] {Name}, {Price}, season:  {Season}\n" + $"price with discount: {PriceWithDiscount}";
    }
}
