using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    public class ArchivedStudent : Student, IComparable<Student>
    {
        private int finalScore;
        public new int FinalScore { get { return finalScore; } set { finalScore = value; } }

        public new string FirstName { get { return Name.Split(' ')[0]; } }
        public new string LastName { get { return Name.Split(' ')[1]; } }

        public ArchivedStudent(string name, string address, string program, int year, double fee, int finalScore) 
            : base(name, address, program, year,fee)
        {//not sure if/when this will ever be used, but whatevs
            FinalScore = finalScore;
        }

        public ArchivedStudent(string name, int finalScore)
        {
            Name = name;
            FinalScore = finalScore;
        }

        public ArchivedStudent()
        {//default constructor
            FinalScore = 0;
        }

        public override string ToString()
        {
            return $"{this.Name,-25} {this.FinalScore,-3}";
        }

        

        //public override string ToString()
        //{
        //    return $@"Archived Student:
        //----------------
        //{"Name:",-13} {Name} 
        //{"Address:",-13} {Address}
        //{"Program:",-13} {Program}
        //{"Year:",-13} {Year}
        //{"Fee:",-13} {Fee}
        //{"Final Score:",-13} {FinalScore}";
        //}


    }
}
