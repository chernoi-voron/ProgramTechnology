using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace Online_Courses;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("загрузка из памяти - 1");
            Console.WriteLine("загрузка из cvs файла - 2");
            var choise = Console.ReadLine();
            if (!(int.TryParse(choise, out var result))) { throw new Exception("Некорректно выбран номер"); }

          
            List<Course> courses = null;
            List<Teacher> teachers = null;
            List<Student> students = null;

            switch (result)
            {
                case 1:
                    {
                        var repo = new InMemoryRepository();
                        courses = repo.GetCourses();
                        teachers = repo.GetTeachers();
                        students = repo.GetStudents();
                        break;
                    }
                case 2:
                    {
                        var repo2 = new CsvRepository(@"G:\С# HomeWorks\Online_Courses\Online_Courses\");
                        courses = repo2.GetCourses();
                        teachers = repo2.GetTeachers();
                        students = repo2.GetStudents();
                        break;

                    }
                default: Console.WriteLine("Некорректный выбор"); Environment.Exit(0); break;

            }

            //string coursetest = "C++ для продвинутых";
            Console.WriteLine("Введите интересующий предмет чтобы найти учителя");
            var coursetest = Console.ReadLine();
            Console.WriteLine(FindTeacher(coursetest, courses, teachers));

            Console.WriteLine("Введинте интересующий предмет чтобы найти студента");
            var coursestud = Console.ReadLine();
            Console.WriteLine(FindStudent(coursestud, courses, students));

            Console.WriteLine("Выберите количество студентов для топа");
            var xrl = Convert.ToInt16(Console.ReadLine());
            if (GetTopStudents(xrl, students) == 0) { Console.WriteLine("0"); }

            Console.WriteLine();

            Console.WriteLine(GetTotalDuration(courses) + " часов");
            Console.WriteLine();

            Console.WriteLine("Все курсы со студентами и учителями");
            PrintAllCourses(courses, students, teachers);


        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }


    }
    /// <summary>
    /// Метод который находит учителя по названию курса
    /// </summary>
    /// <param name="coursename">курс по которому ищется студент</param>
    /// <param name="courses"></param>
    /// <param name="teachers"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    static string FindTeacher(string coursename, List<Course> courses, List<Teacher> teachers)
    {
        if (teachers is null || teachers.Count == 0)
        {
            throw new Exception("Список учителей пуст");
        }
        if (courses is null || courses.Count == 0)
        {
            throw new Exception("Список курсов пуст");
        }
        foreach (var c1 in courses)
        {
            bool foundteacher = false;
            if (c1.Title == coursename)
            {



                foreach (var c3 in teachers)
                {
                    if (c3.Id == c1.TeacherId)
                    {
                        Console.WriteLine(c3.Getinfo());
                        foundteacher = true;
                    }
                }


                if (!foundteacher)
                {
                    Console.WriteLine("Преподаватель для этого курса не найден");
                    return null;
                }

            }
            if (foundteacher)
            {
                return " ";
            }


        }
        Console.WriteLine("Данный курс не найден");
        return null;


    }
    /// <summary>
    /// Метод находящий студента по названию курса
    /// </summary>
    /// <param name="coursename">курс по которому ищется учитель</param>
    /// <param name="courses"></param>
    /// <param name="students"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    static string FindStudent(string coursename, List<Course> courses, List<Student> students)
    {
        if (students is null || students.Count == 0)
        {
            throw new Exception("Список студентов пуст");
        }
        if (courses is null || courses.Count == 0)
        {
            throw new Exception("Список курсов пуст");
        }
        int iffoundcourse = -1;
        foreach (var c1 in courses)
        {
            if (c1.Title == coursename)
            {
                iffoundcourse = c1.Id;
            }
        }
        if (iffoundcourse == -1)
        {
            Console.WriteLine("Данный студент не найден");
            return null;
        }
        bool founStud = false;
        foreach (var c2 in students)
        {

            if (c2.CourseId == iffoundcourse)
            {
                Console.WriteLine(c2.Getinfo());
                founStud = true;
            }
        }
        if (founStud)
        {
            return " ";
        }
        return null;

    }
    /// <summary>
    /// Находит топ н студентов
    /// </summary>
    /// <param name="x">количество студентов в топе</param>
    /// <param name="studentx"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    static int GetTopStudents(int x, List<Student> studentx)
    {
        if (studentx is null || studentx.Count == 0)
        {
            throw new Exception("Список студентов пуст");
        }
        if (x <= 0) { throw new Exception("Отрицательный курс"); }

        List<Student> topStudents = new List<Student>();
        Student progr;
        int b = 1;

        foreach (var student in studentx)
        {
            topStudents.Add(student);
        }
        while (b < topStudents.Count)
        {
            for (int i = 0; i < topStudents.Count - b; i++)
            {
                if (topStudents[i + 1].Progress < topStudents[i].Progress)
                {
                    progr = topStudents[i];
                    topStudents[i] = topStudents[i + 1];
                    topStudents[i + 1] = progr;

                }
            }
            b++;
        }
        if (x > topStudents.Count)
        {

            Console.WriteLine("Студентов меньше чем мест в топе");
            for (int i = topStudents.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(topStudents[i].Getinfo());
            }
            return 1;
        }
        for (int i = topStudents.Count - 1; i > topStudents.Count - x - 1; i--)
        {
            Console.WriteLine(topStudents[i].Getinfo());
        }
        return 1;


    }
    /// <summary>
    ///  Метод находящий общее время всех курсов
    /// </summary>
    /// <param name="courses"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    static int GetTotalDuration(List<Course> courses)
    {
        if (courses is null) { throw new Exception("Нулевая ссылка"); }
        int x = 0;
        foreach (var course in courses)
        {
            x += course.Duration;
        }
        return x;

    }
    /// <summary>
    /// Выводит информацию о всех курсах
    /// </summary>
    /// <param name="courses"></param>
    /// <param name="students"></param>
    /// <param name="teachers"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    static string PrintAllCourses(List<Course> courses, List<Student> students, List<Teacher> teachers)
    {
        string printf = "-";
        if (courses is null || students is null || teachers is null) { throw new Exception("Нулевая ссылка"); }
        if (courses.Count == 0) { Console.WriteLine(printf); }
        foreach (var course in courses)
        {
            printf = course.Title + $" ( {course.Duration.ToString()}, {course.Price.ToString()} ) - ";
            foreach (var teacher in teachers)
            {


                if (course.TeacherId == teacher.Id)
                {
                    printf += "преподаватель " + teacher.Fullname + ',';
                }

            }
            foreach (var student in students)
            {


                if (student.CourseId == course.Id)
                {
                    printf += " студент " + student.Getinfo();
                }

            }
            Console.WriteLine(printf);

        }
        return printf;
    }

}
