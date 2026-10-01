using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Courses;
/// <summary>
/// Класс описывающий учителя
/// </summary>
public class Teacher
{
    /// <summary>
    /// id учителя
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя учителя
    /// </summary>

    public string Fullname { get; set; }
    /// <summary>
    /// Предмет по которому ведёт учитель
    /// </summary>

    public string Subject { get; set; }
    /// <summary>
    /// Конструктор класса учитель
    /// </summary>
    /// <param name="id">id учителя</param>
    /// <param name="fullname"> полное имя учителя</param>
    /// <param name="subject">предмет который ведёт учитель</param>
    public Teacher(int id,string fullname, string subject) 
    {
        if(id <= 0) { throw new ArgumentOutOfRangeException("Некорректные данные"); }
        Id = id;
        if (fullname is null || fullname.Length == 0) { throw new Exception("Некорректные данные"); }
        Fullname = fullname;
        if (subject is null || subject.Length == 0) { throw new Exception("Некорректные данные"); }
        Subject = subject;
    }
    /// <summary>
    /// Конструктор класс учитель без параметров
    /// </summary>
    public Teacher() { }
    /// <summary>
    /// Получение информации об учителе
    /// </summary>
    /// <returns></returns>
    public string Getinfo()
    {
        return Fullname + $"({Subject})";
    }
}
