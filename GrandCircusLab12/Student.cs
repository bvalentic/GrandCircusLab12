using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    public class Student : Person, IComparable<Student>
    {
        private string program;
        private int year;
        private double fee;

        //first and last name fields are used for sorting purposes
        public string FirstName { get { return Name.Split(' ')[0]; } }
        public string LastName { get { return Name.Split(' ')[1]; } }

        //final score set to 0 for printing purposes
        public int FinalScore { get; set; }

        public string Program { get { return program; } set { program = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double Fee { get { return fee; } set { fee = value; } }

        public Student(string name, string address, string program, int year, double fee) : base(name, address)
        {
            Program = program;
            Year = year;
            Fee = fee;
        }

        public Student(string name, string address) : base(name, address)
        {//returns same as default constructor, but allows user to input name and address
            Program = "Undeclared";
            Year = 1;
            Fee = 0;
        }

        public Student(string name)
        {//this is the constructor used for Bonus5
            Name = name;
            if (this.GetType().ToString() == "GrandCircusLab12.Student")
            {
                FinalScore = 0;
            }
        }

        public Student()
        {//default constructor
            Program = "Undeclared";
            Year = 1;
            Fee = 0;
        }

        public override string ToString()
        {//prints only student's name and score
            return $"{this.Name, -25} {this.FinalScore,-3}";
        }

        //I left the old ToString method just in case I want to reuse it

        //public override string tostring()
        //{//returns string of class and attributes
        //    return $@"student:
        //--------
        //{"name:",-8} {name} 
        //{"address:",-8} {address}
        //{"program:",-8} {program}
        //{"year:",-8} {year}
        //{"fee:",-8} ${fee}";
        //}

        public int CompareTo(Student other)
        {//sorts by last name unless they are the same, then sorts by first name
            if (this.LastName == other.LastName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            return this.LastName.CompareTo(other.LastName);
        }
    }
}
