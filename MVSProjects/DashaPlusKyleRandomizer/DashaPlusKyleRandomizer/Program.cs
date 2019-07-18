using System;
using System.Threading;
using System.Linq;

namespace DashasGroupRandomizer
{
    class MainClass
    {
        //method that prints out the list of randomized groups
        public static void PrintGroups(string[] items, int GroupNumber, int NumberOfGroups, int PeopleInGroup)
        {
            Console.Clear();
            // Create a Random object  
            Random rand = new Random();
            while (NumberOfGroups > 0)
            {
                //writes out the groups
                Console.WriteLine($"       Group {GroupNumber}");
                Console.WriteLine("o--------------------o");
                Console.Write(" ");
                for (int i = 0; i < PeopleInGroup; ++i)
                {
                    // Generate a random index less than the size of the array.  
                    int index = rand.Next(items.Length);
                    Console.Write("");
                    //print name
                    Console.Write(items[index] + " ");
                    //remove name at index
                    items = items.Where(val => val != items[index]).ToArray();
                }
                Console.WriteLine();
                ++GroupNumber;
                --NumberOfGroups;
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(100);
            }
        }

        public static void BuildGroups(string[] items)
        {
            //asks for how many groups to build and puts it in NumberOfGroups Variable
            Console.WriteLine(@"o-------------------------------------------o");
            Console.WriteLine(@"|   How many groups do you want to build?   |");
            Console.WriteLine(@"o-------------------------------------------o");
            int NumberOfGroups = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();

            //figures out how big the groups should be
            if (NumberOfGroups <= items.Length / 2)
            {
                //because ints cant have decimals, two variables are made in case groups can't be evenly split
                //for example -- if numberofgroups is 4... 15/4 = *3* and 15/4 + 1 = *4*
                int PeopleInShortGroup = items.Length / NumberOfGroups;
                int PeopleInLongGroup = items.Length / NumberOfGroups + 1;

                //figures out the sizes of the groups
                int LongGroups = items.Length % NumberOfGroups;
                int ShortGroups = NumberOfGroups - LongGroups;

                //We start at Group #1
                int GroupNumber = 1;

                //runs the printgroups method twice, once for long groups and once for short groups
                PrintGroups(items, GroupNumber, LongGroups, PeopleInLongGroup);
                PrintGroups(items, GroupNumber, ShortGroups, PeopleInShortGroup);
            }
            else
            {
                Console.WriteLine("Sorry, that's too many groups for this session." +
                    "\nSome people will have to work alone." +
                    "\nChoose a different number.");
                //Recursion!
                BuildGroups(items);
            }
        }

        //main piece of code, runs RandomizeUs with the list of names as an argument
        public static void Main(string[] args)
        {
            string[] AcademySession8 = { "Ellie", "Chris", "Kyle", "Kat", "Taylor",
                                          "Dasha", "Clarke", "Scott", "Lilith", "Jeff",
                                            "TJ", "Myles", "Hank", "Hayes", "Stan" };
            //FLAVOR TEXT
            OpeningScreen();

            BuildGroups(AcademySession8);
        }

        public static void OpeningScreen()
        {
            string[] output = new string[]{
            @"     .    /\   .     .",
            @" .       /  \    .      ",
            @"   .    /    \ .     .   ",
            @"      ~ Dasha's ~       ",
            @"      /        \    .    ",
            @" .   /          \      ",
            @"    /    Group   \    . ",
            @"    \ Randomizer /      ",
            @"   . \          / .     ",
            @"      \        /     . ",
            @"     (Kyle helped)       ",
            @" .      \    /         ",
            @"    .    \  /    .     ",
            @"   .      \/  .      .   "};

            foreach (string s in output)
            {
                Console.WriteLine(s);
                Thread.Sleep(75);
            }

            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}