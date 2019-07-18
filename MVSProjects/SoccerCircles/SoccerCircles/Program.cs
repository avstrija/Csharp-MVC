using System;

namespace SoccerCircles
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius of your center circle: ");
            string r = Console.ReadLine();
            double radius = Convert.ToDouble(r);
            double area = Math.PI * radius * radius;
            double paint = area / 100;
            Console.WriteLine(area);
            Console.WriteLine("How many buckets of paint do you have?");
            string b = Console.ReadLine();
            double buckets = Convert.ToDouble(b);
            Console.WriteLine("It will take " + area / 100 + " buckets of paint to cover the " + radius + "' radius circle.");
            if (buckets >= area) {
                Console.WriteLine("You have enough paint.");
            }
            else {
                Console.WriteLine("You don't have enough paint.");
            }

            //Colors + Dollars
            double red = paint;
            double blue = area / 120;
            double green = area / 90;
            double yellow = area / 70;

            Console.WriteLine("What color is your paint?");
            string color = Console.ReadLine().ToLower();

            double output = 0;
            double cost = 0;
            if (color == "red") {
                output = red;
                cost = output * 25;
            }
            else if (color == "blue")
            {
                output = blue;
                cost = output * 28;
            }
            else if (color == "green")
            {
                output = green;
                cost = output * 33;
            }
            else if (color == "yellow")
            {
                output = yellow;
                cost = output * 22;
            }
            else {
                color = "unknown";
            }
            Console.WriteLine("It will take " + output + " buckets of " + color + " paint to cover the " + radius + "' radius circle. It will cost you $" + cost + ".");

            // 


        }
    }
}

// You are helping with a local soccer league
// They need to be able to paint their fields
// to mark the center circle. Different leagues
// have different sized circles, however. Make
// a program that will ask for the size of the
// circle and then tell them how much paint they
// need to cover the center circle. The paint
// they use covers about 100 sq ft per bucket.
// Make sure they have enough paint, it's ok
// if there is some extra left in the last
// bucket

// Show the output like this:
// It will take 8 buckets to paint the 15' radius circle

// Bonus: Different colors cover better than
// others. Let the user pick the color and show
// the result. The colors are as follows:
// Red = 100 sq ft/bucket
// Blue = 120 sq ft/bucket
// Green = 90 sq ft/bucket
// Yellow = 70 sq ft/bucket

// Extra Bonus: The colors also cost different
// amounts. Tell the user how much it will cost
// to paint their field.
// Red = 25$ / bucket
// Blue = 28$ / bucket
// Green = 33$ / bucket
// Yellow = 22$ / bucket