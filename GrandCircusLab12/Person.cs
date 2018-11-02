using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    public class Person
    {
        private string name;
        private string address;

        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }

        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public Person()
        {//default constructor
            Name = "John Doe";
            Address = "123 Anywhere St";
        }

        public override string ToString()
        {//prints person's class and attributes
            return $@"Person:
-------
{"Name:",-8} {Name}
{"Address:",-8} {Address}";
        }
    }
}
