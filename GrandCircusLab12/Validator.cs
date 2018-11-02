using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrandCircusLab12
{
    class Validator
    {
        public static string CheckName(string promptString, string errorMessage)
        {//checks a name was entered (two words starting with an uppercase letter)
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            while (!(Regex.IsMatch(inputString, @"([A-Z])\w+\s+([A-Z])\w+")))
            {
                Console.Write($"I'm sorry, that's not a valid input. {errorMessage}");
                inputString = Console.ReadLine();
            }
            return inputString;
        }

        public static bool CheckYes(string promptString)
        {//checks if user input is yes or no and returns a corresponding bool
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            while (!(inputString == "yes" || inputString == "y" || inputString == "no" || inputString == "n"))
            {
                Console.WriteLine($"I'm sorry, that's not a valid input. Please enter \"yes\" or \"no\": ");
                inputString = Console.ReadLine();
            }
            if (inputString == "yes" || inputString == "y")
            {
                return true;
            }
            else return false;
        }

        public static int CheckNum(string promptString, int minNum, int maxNum)
        {//checks input string is of required type (in this case, non-zero positive doubles)
            Console.Write(promptString);
            string inputString = Console.ReadLine();
            int input;
            while ((!(int.TryParse(inputString, out input))) || int.Parse(inputString) < minNum || int.Parse(inputString) > maxNum)
            {//only positive non-zero numbers allowed
                Console.Write($"I'm sorry, that's not a valid input. Please enter a number between {minNum} and {maxNum}: ");
                inputString = Console.ReadLine();
            }
            return input;
        }
    }
}
