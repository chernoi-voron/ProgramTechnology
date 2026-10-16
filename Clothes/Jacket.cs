using System;
namespace Clothes;
/// <summary>
/// Класс Jacket наследующий Clothing и IWashable
/// </summary>
public class Jacket : Clothing, IWashable
{
    /// <summary>
    /// Свойство содержащее информацию в находится ли одежда в стирке
    /// </summary>
    public bool Is_wash { get; set; } = false;
    /// <summary>
    /// Свойство содержащее информацию в находится ли одежда в носке
    /// </summary>
    public bool Is_worn { get; set; } = false;
    /// <summary>
    /// Свойство о степень изоляции
    /// </summary>
    public int Insulation { get; set; }
    /// <summary>
    /// Свойство проверяющее тёплая ли одежда
    /// </summary>
    public bool IsWarm { get { if (Insulation > 50) return true; return false; } }

    /// <summary>
    /// Конструктор Jacket с четырьмя параметрами
    /// </summary>
    /// <param name="sku">Задаваемый артикул</param>
    /// <param name="name">Задаваемое имя</param>
    /// <param name="price">Задаваемая цена</param>
    /// <param name="insulation">Задаваемая степень изоляции</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Jacket(string sku, string name, decimal price, int insulation) : base(sku,name,price) 
    {
        if (insulation < 0 || insulation > 100) throw new ArgumentOutOfRangeException("The insulation must be more or equal zero or less than 101");
        Insulation = insulation;
    }
    /// <summary>
    ///  Конструктор Jacket с одним параметром
    /// </summary>
    /// <param name="name">Задаваемое имя</param>
    public Jacket(string name) : base(name) 
    {
        Insulation = 0;
    }

    /// <summary>
    ///Переопределённый метод Wear одевающий одежду если она не в стирке
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
    /// Переопредлённый метод ToString Возвращающий информацию о куртке
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[Jacket] {Name}, {Price}, season:  {Season}\n" + $"price with discount: {PriceWithDiscount}";
    }
}
