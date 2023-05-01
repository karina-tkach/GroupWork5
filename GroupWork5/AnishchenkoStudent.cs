using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_5_2
{
    public partial class Anishchenko
    {
        struct Student
        {
            public string surname;
            public string name;
            public string patronymic;

            public char sex;
            public DateTime dateOfBirth;
            public char math;
            public char physics;
            public char informatics;
            public int scholarship;

            public Student(string surname, string name, string patronymic, char n, DateTime date, char math, char physics, char informatics, int scholarship)
            {
                this.surname = surname;
                this.name = name;
                this.patronymic = patronymic;
                this.sex = n;
                this.dateOfBirth = new DateTime(date.Ticks);
                this.math = math;
                this.physics = physics;
                this.informatics = informatics;
                this.scholarship = scholarship;
            }

            public Student(string str)
            {
                string[] strarr = str.Split(' ');
                this.surname = strarr[0];
                this.name = strarr[1];
                this.patronymic = strarr[2];
                this.sex = Convert.ToChar(strarr[3]);
                string[] date = strarr[4].Split(':');
                this.dateOfBirth = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                this.math = Convert.ToChar(strarr[5]);
                this.physics = Convert.ToChar(strarr[6]);
                this.informatics = Convert.ToChar(strarr[7]);
                this.scholarship = int.Parse(strarr[8]);
            }

            public override string ToString()
            {
                return $"{this.surname} {this.name} {this.patronymic} {this.sex} {this.dateOfBirth.Day}:{this.dateOfBirth.Month}:{this.dateOfBirth.Year} {this.math} {this.physics} {this.informatics} {this.scholarship}";
            }
        }
    }
}
