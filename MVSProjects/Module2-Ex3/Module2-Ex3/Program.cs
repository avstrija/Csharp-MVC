using System;

namespace Module2Ex3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] simple = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] over_19 = { "twenty", "thirty", "fourty", " fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] over_9 = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            Console.WriteLine("Please enter a number:");
            string input = Console.ReadLine();
            int number = Convert.ToInt16(input);
            string output = "";

            if (number == 0) {
                output = "zero";
            }
            if (number < 0) {
                output += "negative ";
                number = -number;
            }
            if (number >= 1000) {
                int index = number / 1000 - 1;
                output += simple[index] + " thousand";
                number = number % 1000;
                if (number >= 100) {
                    output += ", ";
                }
                else if (number > 0) {
                    output += " and ";
                }
            }
            if (number >= 100)
            {
                int index = number / 100 - 1;
                output += simple[index] + " hundred";
                number = number % 100;
                if (number > 0) {
                    output += " and ";
                }
            }
            if (number >= 20)
            {
                int index = number / 10 - 2;
                output += over_19[index];
                number = number % 10;
                if (number > 0)
                {
                    output += "-";
                }
            }
            if (number >= 10)
            {
                int index = number / 10 - 1;
                output += over_9[index];
                number = number % 10;
            }
            if (number >= 1)
            {
                int index = number - 1;
                output += simple[index];
            }

            Console.WriteLine(output);

        }
    }
}
