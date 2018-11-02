using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    class Staff : Person
    {
        private string school;
        private double pay;

        public string School { get { return school; } set { school = value; } }
        public double Pay { get { return pay; } set { pay = value; } }

        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            School = school;
            Pay = pay;
        }

        public Staff(string name, string address) : base(name, address)
        {//same as default constructor but allows user to input name and address
            School = "currently between schools";
            Pay = 0;
        }

        public Staff() : base()
        {//default constructor
            School = "currently between schools";
            Pay = 0;
        }

        public override string ToString()
        {//returns string of class and attributes
            return $@"Staff:
------
{"Name:",-8} {Name}
{"Address:",-8} {Address}
{"School",-8} {School}
{"Pay:",-8} ${Pay}";
        }
    }
}
