using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_5_2
{
    public partial class Anishchenko
    {
        static List<Student> ReadData(string filename, out bool isValid)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.UTF8);
            if(sr.Peek() == -1)
            {
                isValid= false;
            }
            else
            {
                isValid= true;
            }

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                list.Add(new Student(line));
            }

            return list;
        }

        public void Menu()
        {
            List<Student> list = new List<Student>();
            bool b = true;
            while (b)
            {
                Console.WriteLine("1: Надрукувати список учнів\n2: Додати учня\n3: Записати в файл\n4: Завантажити з файлу\n5: Вивести прізвища студентів що мають усі задовільні оцінки та не отримують стипендію\n0: Завершення роботи програми");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            foreach (Student s in list)
                            {
                                Console.WriteLine(s.ToString());
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Напишіть в форматі: Прізвище Ім'я По_батькові Стать День_нарождження:Місяць_Народження:Рік_Народження Оцінка_з_Математики Оцінка_з_Фізики Оцінка_з_Інформатики Розмір_стипендії");
                            string[] strarr = Console.ReadLine().Split(' ');
                            string surname = strarr[0];
                            string name = strarr[1];
                            string patronymic = strarr[2];
                            char sex = Convert.ToChar(strarr[3]);
                            string[] date = strarr[4].Split(':');
                            DateTime dateOfBirth = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                            char math = Convert.ToChar(strarr[5]);
                            char physics = Convert.ToChar(strarr[6]);
                            char informatics = Convert.ToChar(strarr[7]);
                            int scholarship = int.Parse(strarr[8]);
                            list.Add(new Student(surname, name, patronymic, sex, dateOfBirth, math, physics, informatics, scholarship));
                            break;
                        }
                    case 3:
                        {
                            WriteData(list);
                            break;
                        }
                    case 4:
                        {
                            bool isValid = false;
                            list = ReadData("dataAn.txt", out isValid);
                            if(isValid)
                            {
                                Console.WriteLine("Файл зчитано успішно");
                            }
                            else
                            {
                                Console.WriteLine("Файл пустий");
                            }
                            break;
                        }
                    case 5:
                        {
                            foreach (Student student in list)
                            {
                                if ((student.math == '5') & (student.physics == '5') & (student.informatics == '5') & (student.scholarship == 0))
                                {
                                    Console.WriteLine(student.surname);
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            b = false;
                            break;
                        }


                }
                Console.ReadLine();
            }
        }

        static void WriteData(List<Student> list)
        {

            StreamWriter sw = new StreamWriter("student.txt", false, System.Text.Encoding.UTF8);
            foreach (Student s in list)
            {
                sw.WriteLine(s.ToString());
            }
            sw.Flush();
            sw.Close();
        }
    }
}
