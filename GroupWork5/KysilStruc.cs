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
                List<string> listwords = new List<string>();
                listwords.Add(data[0]);
                listwords.Add(data[1]);
                listwords.Add(data[2]);
                bool invalid = false;
                foreach (string s in listwords)
                {
                    foreach (char ch in s)
                    {
                        if (!(Char.IsLetter(ch) || ch == '\'' || ch == '-'))
                        {
                            invalid = true;
                        }
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
                if (data[3] != "M" && data[3] != "F" && data[3] != "М" && data[3] != "Ч" && data[3] != "Ж")
                {
                    sex = '0';
                }
                else
                {
                    sex = Convert.ToChar(data[3]);
                }
                string[] str = data[4].Split(".");
                if (str[0].Length != 2 || str[1].Length != 2 || str[2].Length != 4)
                {
                    dateOfBirth = null;
                }
                else
                {
                    dateOfBirth = data[4];
                }
                List<string> listmarks = new List<string>();
                listmarks.Add(data[5]);
                listmarks.Add(data[6]);
                listmarks.Add(data[7]);
                invalid = false;
                foreach (string st in listmarks)
                {
                    if ((Convert.ToChar(st) > '5' || Convert.ToChar(st) < '2') && Convert.ToChar(st) != '-')
                    {
                        invalid = true;
                    }
                }
                if (invalid)
                {
                    mathematicsMark = '0';
                    physicsMark = '0';
                    informaticsMark = '0';
                }
                else
                {
                    mathematicsMark = Convert.ToChar(data[5]);
                    physicsMark = Convert.ToChar(data[6]);
                    informaticsMark = Convert.ToChar(data[7]);
                }
                if ((Convert.ToInt32(data[8]) < 1234 || Convert.ToInt32(data[8]) > 4321) && Convert.ToInt32(data[8]) != 0)
                {
                    scholarship = -1;
                }
                else
                {
                    scholarship = Convert.ToInt32(data[8]);
                }
            }
            public override string ToString()
            {
                return $"{surName} {firstName} {patronymic} {sex} {dateOfBirth} {mathematicsMark} {physicsMark} {informaticsMark} {scholarship}";
            }
        }
    }
}
