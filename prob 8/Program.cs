using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Student
{
    public string FirstName;
    public string LastName;
    public int[] Mark;

    public Student(string firstName, string lastName, int[] mark) //створюємо студента
    {
        FirstName = firstName;
        LastName = lastName;
        Mark = mark;
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
                    int[] temp = new int[action.Length - 2]; // для запису оцінок
                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = Convert.ToInt32(action[i + 2]); // запис оцінки

                    students.Add(new Student(action[0], action[1], temp)); // додавання студента
                }
            }
        }

        var SelectedStudents = from st in students // кожен елемент з students педерається в st
                               where st.Mark.Where(m => m <= 3).Count() >= 2 // перевіряє на наявність оцінок менших за 3 включно(мін2оцінки)
                               select st; // об'єкт який іде в SelectedStudents

        foreach (var student in SelectedStudents) // вивід студентів з SelectedStudents
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }


        Console.ReadKey();
    }
}


