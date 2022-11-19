using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Student
{
    public string FirstName;
    public string LastName;
    public int Group;

    public Student(string firstName, string lastName, int group) //створюємо студента
    {
        FirstName = firstName;
        LastName = lastName;
        Group = group;
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
                else if (action.Length >= 3)
                {
                    students.Add(new Student(action[0], action[1], Convert.ToInt32(action[2]))); // додавання студента
                }
            }
        }

        var Groups = students
                       .GroupBy(st => st.Group) // групується за групою
                       .OrderBy(g => g.Key); // згрупований результат сортирується за ключем(групою)

        foreach (var group in Groups) // вивід студентів з Groups
        {
            Console.Write(group.Key + " - "); // виведення ключа(групи)

            List<string> temp = new(); // для імен студентів
            foreach (var student in group)
                temp.Add(student.FirstName); // записування кожного студента з цієї групи

            Console.WriteLine(string.Join(", ", temp)); // вивід імен студентів
        }

        Console.ReadKey();
    }
}



