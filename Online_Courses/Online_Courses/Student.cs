using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Courses;
/// <summary>
/// Класс студента 
/// </summary>
public class Student
{
    /// <summary>
    /// Id студента
    /// </summary>
    public int Id { get; set; }
   /// <summary>
   /// Полное имя студента
   /// </summary>
    public string Fullname { get; set; }

    /// <summary>
    /// id курса
    /// </summary>
    public int CourseId { get; set; }
    /// <summary>
    /// почта студента
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// прогресс студента по курсу
    /// </summary>
    public int Progress { get; set; }
    /// <summary>
    /// Конструктор класса студента
    /// </summary>
    /// <param name="id"> id студента</param>
    /// <param name="fullname"> полное имя студента</param>
    /// <param name="courseid">id курса студента</param>
    /// <param name="email"> почта студента</param>
    /// <param name="progress">прогресс студента по курсу</param>
    /// <exception cref="Exception"></exception>
    public Student(int id, string fullname, int courseid, string email, int progress) 
    {
        if (id <= 0) { throw new Exception("Некорректные данные"); }
        Id = id;
        if (fullname is null ||fullname.Length <= 0) { throw new Exception("Некорректные данные"); }
        Fullname = fullname;
        if (courseid <= 0) { throw new Exception("Некорректные данные"); }
        CourseId = courseid;
        if (email is null ||email.Length <= 0) { throw new Exception("Некорректные данные"); }
        Email = email;
        if (progress >= 0 || progress <= 100)
        {
            Progress = progress;
        }
        else { throw new Exception("Не корректный прогресс"); }
    }
    /// <summary>
    /// Конструктор класса студента без параметров
    /// </summary>
    public Student() 
    {

    }
    /// <summary>
    /// свойство класса определяющее "отличный" результат
    /// </summary>
    public string IsExcellent
    {
        get
        {
            if (Progress >= 90)
            {
                return "Отличный результат";
            }
            else
            {
                return $"До отличного результата не хватает {90 - Progress}%";
            }
        }
    }
    /// <summary>
    /// свойство класса определяющее плохой результат
    /// </summary>
    public string IsFailing
    {
        get 
        {
            if (Progress < 50)
            {
                return "Плохой результат";
            }
            else
            {
                return $"Не плохой результат до отлично необходимо {90 - Progress}% ";
            }

        }
    }
    /// <summary>
    /// Получение информации о студенте
    /// </summary>
    /// <returns></returns>
    public string Getinfo()
    {
        return Fullname + $" (прогресс {Progress}%)";
    }
    
}
