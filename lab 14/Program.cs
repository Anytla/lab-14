using System;
using System.Collections.Generic;
using System.Linq;


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
                else if (action.Length == 3)
                {
                    students.Add(new Student(action[0], action[1], Convert.ToInt32(action[2]))); // додавання студента
                }
            }
        }

        var SelectedStudents = from st in students // кожен елемент з students педерається в st
                               where st.Group == 2 // при умові що буде в 2 групі
                               orderby st.FirstName // сортирування по спаданню за іменем
                               select st; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }


        Console.ReadKey();
    }
}
