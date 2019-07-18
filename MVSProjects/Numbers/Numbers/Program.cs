using System;

namespace Numbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Name
            string name;
            string letter;
            Console.WriteLine("This is part 1");
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("Pick a letter");
            letter = Console.ReadLine().ToLower();
            if (name.ToLower().Contains(letter)) {
                Console.WriteLine("Your name contains letter " + letter);
            }
            else {
                Console.WriteLine("Your name doesn't contain letter " + letter);
            }

            if (name.Length > 10) 
            {
                Console.WriteLine("You have a long name");
            }
            else
            {
                Console.WriteLine("Your name is not that long");
            }


            //Garden
            string input_length;
            Console.WriteLine("Enter the length of your garden: ");
            input_length = Console.ReadLine();
            double length = Convert.ToInt32(input_length);

            string input_width;
            Console.WriteLine("Enter the width of your garden: ");
            input_width = Console.ReadLine();
            double width = Convert.ToInt32(input_width);
            double area = length * width;
            double corn = (area * 3 / 16) - (area * 3 / 16) % 1;
            double beets = (area * 9 / 16) - (area * 9 / 16) % 1;

            //Console.WriteLine("Your garden is: " + length + " by " + width + " square feet ");
            //Console.WriteLine("The area of your garden is: " + area);
            //Console.WriteLine("The perimeter of your garden is: " + (length + width)*2);
            Console.WriteLine("What do you want to plant?");
            string response = Console.ReadLine().ToLower();
            if (response == "carrots" || response == "carrot")
            {
                Console.WriteLine("You can plant " + (area - area % 1) + " carrots in your garden.");
            }
            else if (response == "corn")
            {
                Console.WriteLine("You can plant " + corn + " corn stocks in your garden.");
            }
            else if (response == "beets" || response == "beet")
            {
                Console.WriteLine("You can plant " + beets + " beets in your garden.");
            }
            else {
                Console.WriteLine("You shouldn't plant " + response + ". It's illegal!");
            }

        }
    }
}


//string input_length;
//Console.WriteLine("Enter the length: ");
//input_length = Console.ReadLine();
//int length = Convert.ToInt32(input_length);

//string input_width;
//Console.WriteLine("Enter the width: ");
//input_width = Console.ReadLine();
//int width = Convert.ToInt32(input_width);

//Console.WriteLine("Your garden is: " + length + " by " + width + " square feet ");
//Console.WriteLine("The area of your garden is: " + length* width);
//Console.WriteLine("The perimeter of your garden is: " + (length + width)*2);
//Console.WriteLine("Your need: " + length* width * 2 / 3 + " bags of soil");