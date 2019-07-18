using System;

namespace Evaluations12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Exercise 1
            Console.WriteLine("Please enter your first name:");
            string first = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string last = Console.ReadLine();
            Console.WriteLine("Hello " + first + " " + last + "!");

            //Exercise 2
            Console.WriteLine("Hello! Welcome to the garden bed builder.\n" +
                "Enter the size of your garden bed and I will tell you \n" +
                "what to buy at the hardware store.\n" +
                "First, tell me the length of your garden bed in feet.");
            string l = Console.ReadLine();
            int length = Convert.ToInt16(l);
            Console.WriteLine("Next, tell me the width of your garden bed in feet.");
            string w = Console.ReadLine();
            int width = Convert.ToInt16(w);
            Console.WriteLine("Now, how many boards high do you want to go?");
            string b = Console.ReadLine();
            int board_height = Convert.ToInt16(b);

            double perimeter = (length + width) * 2;
            double area = length * width;
            Console.WriteLine("The Perimeter of your garden is: " + perimeter + " ft");
            Console.WriteLine("The Area of your garden is: " + area + " sq/ft");
            Console.WriteLine("You will need to buy:\n" + perimeter * board_height + " ft of boards\n" +
                area * board_height / 2 + " bags of dirt");

            //Exercise 3
            Console.WriteLine("Enter a number to start.");
            string s = Console.ReadLine();
            int num_1 = Convert.ToInt16(s);
            Console.WriteLine("Enter a number to end.");
            string e = Console.ReadLine();
            int num_2 = Convert.ToInt16(e);
            while (num_1 <= num_2) {
                string output = Convert.ToString(num_1); ;
                if (num_1%3 == 0) {
                    output = "fizz";
                }
                if (num_1 % 5 == 0) {
                    output = "buzz";
                }
                if (num_1 % 15 == 0)
                {
                    output = "fizzbuzz";
                }
                Console.WriteLine(output);
                ++num_1;
            
            }



        }
    }
}
