using System;
using System.Collections.Generic;
using System.Linq;


class Student
{
    public string FirstName;
    public string LastName;

    public Student(string firstName, string lastName) //створюємо студента
    {
        FirstName = firstName;
        LastName = lastName;
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
                else if (action.Length == 2)
                {
                    students.Add(new Student(action[0], action[1])); // додавання студента
                }
            }
        }

        var SelectedStudents = from st in students // кожен елемент з students педерається в st
                               where string.Compare(st.FirstName, st.LastName) <= 0 // при умові що буква Ім'я йде перед буквою Прізвища
                               select st; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }


        Console.ReadKey();
    }
}
