using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Lab_2_5_2;
using lab5_2;

namespace GroupWork5
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Головне меню:");
            int choice;
            do
            {
                Console.WriteLine("Якщо ви хочете виконати варiант 8 студентки Ткач К.В введiть 1");
                Console.WriteLine("Якщо ви хочете виконати варiант 13 студентки Кисiль А.О введiть 2");
                Console.WriteLine("Якщо ви хочете виконати варiант 10 студента Анiщенка Д.С введiть 3");
                Console.WriteLine("Щоб вивести вмiст файлу введiть 4");
                Console.WriteLine("Для виходу з програми введiть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Tkach t = new Tkach();
                         t.Base();
                        break;
                    case 2:
                        Console.WriteLine("Прiзвища студентiв, якi пропустили бiльше 2х iспитiв:");
                        Kysil k = new Kysil();
                        k.Mainn();
                        break;
                    case 3:
                        Console.WriteLine("Прiзвища студентiв, якi мають задовiльнi оцiнки i не одержують стипендiї:");
                        Anishchenko a = new Anishchenko();
                        a.Menu();
                        break;
                    case 4:
                        Console.WriteLine("Bмiст файлу:");
                        FileOutput();
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тiльки натиснiть будь ласка ще раз Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Команда \"{0}\" не розпiзнана. Зробiть, будь ласка, вибiр iз 1, 2, 3, 4, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
        static void FileOutput()
        {
            string[] data = File.ReadAllLines("data.txt", Encoding.UTF8);
            foreach (string item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
