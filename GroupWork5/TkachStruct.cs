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
        struct Student
        {
            public string surName;
            public string firstName;
            public string patronymic;
            public char sex;
            public string dateOfBirth;
            public char mathematicsMark;
            public char physicsMark;
            public char informaticsMark;
            public int scholarship;

            public Student(string lineWithAllData)
            {
                string[] data = lineWithAllData.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<string> list1 = new List<string>();
                list1.Add(data[0]); list1.Add(data[1]); list1.Add(data[2]);
                bool invalid = false;

                foreach (string a in list1)
                {
                    if (!a.All(s => Char.IsLetter(s) || s == '\'' || s == '-'))
                    {
                        invalid = true;
                    }
                }
                if (invalid)
                {
                    surName = null;
                    firstName = null;
                    patronymic = null;
                }
                else
                {
                    surName = data[0];
                    firstName = data[1];
                    patronymic = data[2];
                }

                if (data[3] != "M" && data[3] != "М" && data[3] != "Ч" && data[3] != "Ж" && data[3] != "F")
                {
                    sex = '\0';
                }
                else
                {
                    sex = Convert.ToChar(data[3]);
                }

                if (!Regex.IsMatch(data[4], @"^\d{2}\.\d{2}\.\d{4}$"))
                {
                    dateOfBirth = null;
                }
                else
                {
                    dateOfBirth = data[4];
                }

                List<string> list = new List<string>();
                list.Add(data[5]); list.Add(data[6]); list.Add(data[7]);
                invalid = false;
                foreach (string a in list)
                {
                    if ((Convert.ToChar(a) < '2' || Convert.ToChar(a) > '5') && Convert.ToChar(a) != '-')
                    {
                        invalid = true;
                    }
                }
                if (invalid)
                {
                    mathematicsMark = '\0';
                    physicsMark = '\0';
                    informaticsMark = '\0';
                }
                else
                {
                    mathematicsMark = Convert.ToChar(data[5]);
                    physicsMark = Convert.ToChar(data[6]);
                    informaticsMark = Convert.ToChar(data[7]);
                }

                if ((int.Parse(data[8]) < 1234 || int.Parse(data[8]) > 4321) && int.Parse(data[8]) != 0)
                {
                    scholarship = -1;
                }
                else
                {
                    scholarship = int.Parse(data[8]);
                }
            }
            public void Print() => Console.WriteLine($" {surName} {firstName} {patronymic} {sex} {dateOfBirth} {mathematicsMark} {physicsMark} {informaticsMark} {scholarship}");
        }

    }
}
