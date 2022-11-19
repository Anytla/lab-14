using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Student
{
    public string FirstName;
    public string LastName;
    public string Phone;

    public Student(string firstName, string lastName, string phone) //створюємо студента
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
}
class Ex1
{
    static void Main()
    {
        List<Student> students = new(); // колекція студентів

        while (true)
        {
            string[]? action = Console.ReadLine()?.Split(' '); // зчитування команди

            if (action != null)
            {
                if (action[0].ToUpper() == "END")
                {
                    Console.WriteLine();
                    break; // завершення вводу
                }
                else if (action.Length == 3)
                {
                    students.Add(new Student(action[0], action[1], action[2])); // додавання студента
                }
            }
        }

        var SelectedStudents = from st in students // кожен елемент з students педерається в st
                               where new Regex(@"^02").IsMatch(st.Phone) // перевіряє чи на початку стоїть 02
                               where new Regex(@"^\+3592").IsMatch(st.Phone) // перевіряє чи на початку стоїть +3592
                               select st; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
        {
            Console.WriteLine(student);
        }


        Console.ReadKey();
    }
}


