using System;

namespace Calculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("What do you want to calculate?");
            string input = Console.ReadLine();
            int x = 0;
            char operand = 'x';
            int y = 0;
            int index = 0;
            string first = "";
            string last = "";
            int output = 0;

            while(char.IsDigit(input[index])) {
                first += Convert.ToString(input[index]);
                ++index;
            }
            x = Convert.ToInt32(first);
            operand = input[index];
            ++index;

            while (index<input.Length) {
                last += Convert.ToString(input[index]);
                ++index;
            }
            y = Convert.ToInt32(last);

            switch(operand) 
            {
                case '*': 
                    output = x * y;
                    break;
                case '/': 
                    output = x / y;
                    break;
                case '+': 
                    output = x + y;
                    break;
                case '-': 
                    output = x - y;
                    break;
                case '%': 
                    output = x % y;
                    break;
                default: 
                    output = 42;
                    Console.WriteLine("Unknown operation. Try again.");
                    break;
            }
            Console.WriteLine(input + " = " + output);
        }
    }
}
