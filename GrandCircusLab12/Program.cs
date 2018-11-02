using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    class Program
    {
        static void Main(string[] args)
        {//an update to Lab 12 including the Bonus-5 specs 
         //(adding an Archived Student class with a "final score"

            //I commented out the below list because it isn't used in the Bonus-5 version

            //List<Person> personList = new List<Person>
            //{//a list of fictional teachers and students
            // //I added some cases with only a partial list of arguments (or none) to use the other constructors
            // //yes I looked up full names and addresses for these 
            //    new Staff("Severus Snape", "Hogwarts", "Potions Class", 50000),
            //    new Student("Harry Potter", "The Cupboard Under the Stairs, 4 Privet Drive", "Hogwarts School of Witchcraft & Wizardry", 3, 30000),
            //    new Staff("Ms. Valerie Felicity Frizzle", "Walkerville", "Magic School Bus", 100000),
            //    new Student("Phoebe Terese", "Phoebe's old school", "Walkerville Elementary", 3, 5000),
            //    new Staff("Charles Xavier", "Westchester County, NY", "Xavier Institute for Higher Learning", 3000000),
            //    new Student("Scott Summers", "Westchester County, NY"),
            //    new Staff("Mrs. Poppy Puff", "3451 Anchor Way, Bikini Bottom"),
            //    new Student("Spongebob Squarepants", "124 Conch Street, Bikini Bottom", "Boating School", 12, 9),
            //    new Staff(),
            //    new Student()
            //};

            List<Student> studentList = new List<Student>
            {//just a simple list which I used to test sorting by name and score
                new Student("John Doe"),
                new ArchivedStudent("Jane Doe", 75),
                new ArchivedStudent("Bob Barker", 100),
                new Student("Alice Barker")
            };

            //PrintPersonList(personList);

            bool keepGoing = true;

            Console.WriteLine("Welcome to the Big Student List!");
            while (keepGoing)
            {
                keepGoing = BigMoney(studentList);
            }

            Console.WriteLine("Thank you!");
            Console.ReadKey();
        }

        static bool BigMoney(List<Student> studentList)
        {//this is the "hub" method that cycles through available choices until the user quits
            bool keepGoing = true;

            Console.WriteLine();
            int inputChoice = Validator.CheckNum(PrintOptions(), 1, 4);

            if (inputChoice == 1)
            {//print list
                Console.WriteLine("The following is a list of students and their scores:\n");
                PrintStudentList(studentList);
            }
            else if (inputChoice == 2)
            {//add a student to the list
                AddToList(studentList);
            }
            else if (inputChoice == 3)
            {//sort the list
                studentList = Sorter(studentList);
            }
            //quit
            else keepGoing = Quitter();
            return keepGoing;
        }

        static bool Quitter()
        {//my standard method to confirm quitting
            bool quit = Validator.CheckYes("Are you sure you want to quit? ");
            if (quit)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nOkay!\n");
                return true;
            }
        }

        static List<Student> Sorter(List<Student> studentList)
        {//sorts student list by name or final score
            bool sortLoop = true;
            do
            {
                Console.Write("Sort by name or score? ");
                string inputString = Console.ReadLine();
                if (inputString.ToLower() == "name")
                {
                    studentList.Sort();
                    Console.WriteLine("Sorted by last name!\n");
                    PrintStudentList(studentList);
                    sortLoop = false;
                }
                else if (inputString.ToLower() == "score")
                {//currently sorting by score doesn't actually sort, work-in-progress
                    studentList.OfType<ArchivedStudent>();
                    studentList = studentList.OrderBy(student => student.FinalScore).ToList();
                    Console.WriteLine("Sorted by final score!\n");
                    PrintStudentList(studentList);
                    sortLoop = false;
                }
                else Console.WriteLine("I'm sorry, I didn't understand. Please enter \"name\" or \"score\": ");
            } while (sortLoop);
            return studentList;
        }

        static string PrintOptions()
        {//list of available choices for the user
            return @"What would you like to do?
1 -- view list of students
2 -- add a student to the list
3 -- sort list
4 -- quit
";
        }

        static void AddToList(List<Student> studentList)
        {//add a student or archived student to the list
            bool isArchived = Validator.CheckYes("Is this student archived? (y/n) ");
            string inputName = Validator.CheckName("Enter a name in first name/last name format: ", "Please enter using this format:\n" +
                "[First] [Last] (be sure both names are capitalized) ");
            if (isArchived)
            {
                int inputScore = Validator.CheckNum("Enter a final score for the archived student: ", 0, 100);
                studentList.Add(new ArchivedStudent(inputName, inputScore));
            }
            else studentList.Add(new Student(inputName));
        }

        static void PrintPersonList(List<Person> personList)
        {//print list of peeps
            Console.WriteLine("The following is a list of teachers and students:\n");

            foreach (Person person in personList)
            {                
                Console.WriteLine(person.ToString());
                Console.WriteLine();
            }
        }

        static void PrintStudentList(List<Student> studentList)
        {//sorts and prints list of students

            Console.WriteLine($"{"Name:",-25} {"Final score (marked 0 if not completed):"}");
            Console.WriteLine($"{"-----",-25} {"-----------"}");
            
            foreach (Student s in studentList)
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine();
            }
        }
    }
}
