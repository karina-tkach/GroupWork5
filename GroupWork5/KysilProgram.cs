using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace lab5_2
{
    partial class Kysil
    {
        public void Mainn()
        {
            List<Student> students = ReadData("data.txt", out bool invalid);
            Menu(students);
            if (invalid)
            {
                Console.WriteLine("Зчитано не весь файл, файл мiстить некоректнi данi");
            }
        }
        static void Menu(List<Student> students)
        {
            foreach (Student st in students)
            {
                if (st.mathematicsMark == '-' && st.physicsMark == '-' && st.informaticsMark == '-')
                {
                    Console.WriteLine(st.surName);
                }
            }
        }
        static List<Student> ReadData(string fileName, out bool invalid)
        {
            string[] data = File.ReadAllLines(fileName, Encoding.UTF8);
            List<Student> list = new List<Student>();
            invalid = false;
            for (int i = 0; i < data.Length; i++)
            {
                Student student = new Student(data[i]);
                if (student.surName == null || student.firstName == null || student.patronymic == null || student.dateOfBirth == null || student.sex == '\0' || student.mathematicsMark == '\0' || student.physicsMark == '\0' || student.informaticsMark == '\0' || student.scholarship == -1)
                {
                    invalid = true;
                }
                else
                {
                    list.Add(student);
                }
            }
            return list;
        }
    }
}
