using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Courses;
/// <summary>
/// Класс описывающий курс
/// </summary>
public class Course
{
    /// <summary>
    /// ID курса
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название курса
    /// </summary>

    public string Title { get; set; }
    /// <summary>
    /// Проверка на уникальные значение курса
    /// </summary>

    Dictionary<string, int> IdTitle = new Dictionary<string, int>();
    /// <summary>
    /// id учителя
    /// </summary>

    public int TeacherId { get; set; }
    /// <summary>
    /// продолжительность курса в часах
    /// </summary>

    public int Duration { get; set; }
    /// <summary>
    /// цена курса
    /// </summary>

    public decimal Price{ get; set; }
    /// <summary>
    /// Конструктор класса курса
    /// </summary>
    /// <param name="id">id курса</param>
    /// <param name="title">название курса</param>
    /// <param name="teacherid">id учителя</param>
    /// <param name="duration">продолжительность курса в часах</param>
    /// <param name="price">цена курса</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public Course(int id, string title, int teacherid,int duration, decimal price) 
    {
        if (id <=0 ) throw new ArgumentOutOfRangeException("Номер курса должен быть положительным");
        Id = id;
        if (title is null) {throw new ArgumentNullException("title");  }
        if (IdTitle.ContainsKey(title))
        {
            throw new Exception("Данный курс уже существует");
        }
        else 
        {
            IdTitle.Add(title, id);
            Title = title;
        }
        if(teacherid <= 0) { throw new Exception("Некорректные данные"); }
        TeacherId = teacherid;
        if (duration <= 0) { throw new Exception("Некорректные данные"); }
        Duration = duration; 
        if (price <= 0) { throw new Exception("Некорректные данные");  }
        Price = price;
    }
    /// <summary>
    /// Конструктор класса курс без параметров
    /// </summary>
    public Course() { }
    /// <summary>
    /// свойство проверяющее насколько курс долгий
    /// </summary>
    public string IsLong
    {
        get 
        {
            if (Duration > 40)
                return "Долгий курс";

            else return "Курс не долгий";
        }

    }
    /// <summary>
    /// Метод получение информации о курсе
    /// </summary>
    /// <returns></returns>
    public string Getinfo()
    {
        return Title + $"({Duration},{Price})";
    }
}
