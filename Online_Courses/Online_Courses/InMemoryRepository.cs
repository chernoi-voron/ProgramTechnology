using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Online_Courses;
/// <summary>
/// Репозиторий берущий информацию из памяти
/// </summary>
public class InMemoryRepository
{
    private List<Course> _courses;
    private List<Student> _students;

    private List<Teacher> _teachers;
    /// <summary>
    /// Конструктор для репозитория из памяти поставляющий данные
    /// </summary>
    public InMemoryRepository()
    {
        _courses = new List<Course>
        {
            new Course(id: 1, title: "C# для начинающих", teacherid: 1, duration: 23, price: 15000),
            new Course(id: 2, title: "C++ для продвинутых", teacherid:2, duration: 45, price: 25000),
            new Course(id: 3, title: "Надводный дайвинг", teacherid:3, duration: 155, price: 322000),
            new Course(id: 4, title: "Веб-дизайн", teacherid: 4, duration: 128, price: 128000),
            new Course(id: 5, title: "3д-моделирование", teacherid: 5, duration: 244, price: 99000),
            new Course(id: 6, title: "Подводный дайвинг", teacherid:6, duration: 1000, price: 1234567)


        };
        _students = new List<Student>
        {
            new Student(id:1,fullname:"Иванов И.П.",courseid:1,email:"ivan.i@gmail.com",progress: 32),
            new Student(id:2,fullname:"Соня Ф.С.",courseid:2,email:"sony.f@gmail.com",progress: 81),
            new Student(id:3,fullname:"Георгий З.Т.",courseid:3,email:"georgie.z@gmail.com",progress: 65),
            new Student(id:4,fullname:"Cавелий М.П.",courseid:4,email:"savelie.m@gmail.com",progress: 91),
            new Student(id:5,fullname:"Кира Д.В.",courseid:5,email:"kira.d@gmail.com",progress: 76),
            new Student(id:6,fullname:"Петр И.З.",courseid:6,email:"petr.i@gmail.com",progress: 59)

        };
        _teachers = new List<Teacher>
        {
            new Teacher(id:4, fullname: "Заянов А.П.",subject:"Моделирование"),
            new Teacher(id:3, fullname: "Умилов В.Д.",subject:"Дайвинг"),
            new Teacher(id:5, fullname: "Тунаев Г.Б.",subject:"Программирование"),
            new Teacher(id:1, fullname: "Энталов Д.И.",subject:"Квантовое проецирование"),
            new Teacher(id:2, fullname:"Стараковский В.И.", subject:"Мореплавание"),
            new Teacher(id:6, fullname:"Кузьмин К.А.",subject:"Подводоплавание")

        }; 
    }
        
    /// <summary>
    /// Метод для получения информации для курса
    /// </summary>
    /// <returns></returns>
    public List<Course> GetCourses() { return _courses; }
    /// <summary>
    /// Метод для получения инфрмации для студентов
    /// </summary>
    /// <returns></returns>
    public List<Student> GetStudents() { return _students; }
    /// <summary>
    /// Метод для получения информации для учителей
    /// </summary>
    /// <returns></returns>
    public List<Teacher> GetTeachers() { return _teachers; }



}
