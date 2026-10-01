using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Courses;
/// <summary>
/// Репозиторий описывающий данные из файла
/// </summary>
public class CsvRepository
{
    private string _basePath;
    /// <summary>
    /// Конструктор для класса csvrepository передающий путь к файлу
    /// </summary>
    /// <param name="basePath"></param>
    public CsvRepository(string basePath) { _basePath = basePath; }
    /// <summary>
    /// Метод преобразующий информацию из файла курсы
    /// </summary>
    /// <returns></returns>
    public List<Course> GetCourses()
    {
        List<Course> result = new List<Course>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "courses.csv"));
        if(lines.Length < 2) return result;
        for(int i = 1;i < lines.Length;i++)
        {
            string[] parts = lines[i].Split(';');
            if(parts.Length < 5  ) continue;
            Course c = new Course();
            if (int.Parse(parts[0]) < 0) { throw new Exception("Некорректный id"); }
            c.Id = int.Parse(parts[0]);
            if (parts[1] is null || parts[1].Length == 0) { throw new Exception("Некорректное название курса"); }
            c.Title = parts[1];
            if (int.Parse(parts[2]) < 0) { throw new Exception("Некорректный id учителя"); }
            c.TeacherId = int.Parse(parts[2]);
            if (int.Parse(parts[3]) < 0) { throw new Exception("Некорректный время курса"); }
            c.Duration = int.Parse(parts[3]);
            if (int.Parse(parts[4]) < 0) { throw new Exception("Некорректная цена"); }
            c.Price = decimal.Parse(parts[4]);
            result.Add(c);
        }
        return result;
    }
    /// <summary>
    /// Метод преобразующий информацию из файла учителей
    /// </summary>
    /// <returns></returns>
    public List<Teacher> GetTeachers()
    {
        List<Teacher> result = new List<Teacher>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "teachers.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if( parts.Length < 3 ) continue;
            Teacher t = new Teacher();
            if (int.Parse(parts[0]) < 0) { throw new Exception("Некорректный id"); }
            t.Id = int.Parse(parts[0]);
            if (parts[1] is null || parts[1].Length == 0) { throw new Exception("Некорректное имя"); }
            t.Fullname = parts[1];
            if (parts[2] is null || parts[2].Length == 0) { throw new Exception("Некорректный предмет"); }
            t.Subject = parts[2];
            result.Add(t);

        }
        return result;
    }
    /// <summary>
    /// Метод преобразующий информацию из файла студентов
    /// </summary>
    /// <returns></returns>
    public List<Student> GetStudents()
    {
        List<Student> result = new List<Student>();
        string[] lines = File.ReadAllLines(Path.Combine(_basePath, "students.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(';');
            if (parts.Length < 5) continue;
            Student s = new Student();
            if(int.Parse(parts[0]) <= 0) { throw new Exception("Некорректный id"); }
            s.Id = int.Parse(parts[0]);
            if (parts[1] is null || parts[1].Length == 0) { throw new Exception("Некорректное имя"); }
            s.Fullname = parts[1];
            if (int.Parse(parts[2]) < 0) { throw new Exception("Некорректный id"); }
            s.CourseId = int.Parse(parts[2]);
            if (parts[3] is null || parts[3].Length ==0) { throw new Exception("Некорректная почта"); }
            s.Email = parts[3];
            if (int.Parse(parts[4]) < 0 || int.Parse(parts[4]) > 100) { throw new Exception("Некорректный прогресс"); }

            s.Progress = int.Parse(parts[4]);
            result.Add(s);
        }
        return result;
    }

}

  
