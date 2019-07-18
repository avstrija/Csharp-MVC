using System;

namespace Module2Ex1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentence:");
            string s = Console.ReadLine().ToLower(); ;
            Console.WriteLine("Please enter a letter:");
            string l = Console.ReadLine().ToLower();
            char letter = Convert.ToChar(l);
            int counter = 0;
            foreach (var a in s) { 
                if (a == letter) {
                    ++counter;
                }
            }
            Console.WriteLine("The letter " + letter + " appears in your sentence " + counter + " times.");
        }
    }
}