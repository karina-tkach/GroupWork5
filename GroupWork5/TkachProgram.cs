using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace GroupWork5
{
    partial class Tkach
    {
        static List<Student> ReadData(string fileName, out bool invalid)
        {
            string[] data = File.ReadAllLines(fileName, Encoding.UTF8);
            List<Student> s = new List<Student>();
            invalid = false;
            for (int i = 0; i < data.Length; i++)
            {
                Student st = new Student(data[i]);
                if (st.surName == null || st.firstName == null || st.patronymic == null || st.dateOfBirth == null || st.sex == '\0' || st.mathematicsMark == '\0' || st.physicsMark == '\0' || st.informaticsMark == '\0' || st.scholarship == -1)
                {
                    invalid = true;
                }
                else
                {
                    s.Add(st);
                }
            }
            return s;
        }

        static void runMenu(List<Student> studs)
        {
            int count = 0;
            for (int i = 0; i < studs.Count; i++)
            {
                if (DateTime.ParseExact(studs[i].dateOfBirth, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture).AddYears(16) > DateTime.Now)
                {
                    count++;
                }
            }
            Console.WriteLine("Число студентiв, якi молодше 16 рокiв та данi про них:");
            Console.WriteLine(count);
            if (count != 0)
            {
                Console.WriteLine("Прiзвище|Iм'я|По батьковi|Стать|Дата народження|Оцiнка з математики|Оцiнка з фiзики|Оцiнка з iнформатики|Стипендiя");
            }
            for (int i = 0, k = 1; i < studs.Count; i++)
            {
                if (DateTime.ParseExact(studs[i].dateOfBirth, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture).AddYears(16) > DateTime.Now)
                {
                    Console.Write(k + " ");
                    studs[i].Print();
                    k++;
                }
            }
        }
        public void Base()
        {
            List<Student> studs = ReadData("data.txt", out bool invalid);
            runMenu(studs);
            if (invalid)
            {
                Console.WriteLine("Зчитано не весь файл, файл мiстить некоректнi данi!");
            }
        }
    }
}
