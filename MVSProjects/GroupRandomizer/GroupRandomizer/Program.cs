using System;

namespace GroupRandomizer
{
    class MainClass
    {
        public static int[] PrintGroups(string[] items, int[] GroupNumberAndIndex, int NumberOfGroups, int PeopleInGroup) {
            while (NumberOfGroups > 0)
            {
                Console.Write($"Group {GroupNumberAndIndex[0]}: ");
                for (int i = GroupNumberAndIndex[1]; i < GroupNumberAndIndex[1] + PeopleInGroup; ++i)
                {
                    Console.Write(items[i] + " ");
                }
                GroupNumberAndIndex[1] += PeopleInGroup;
                ++GroupNumberAndIndex[0];
                --NumberOfGroups;
                Console.WriteLine();
            }
            return GroupNumberAndIndex;
        }

        public static void RandomizeUs(string[] items)
        {
            Random rand = new Random();

            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                string temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }

            Console.WriteLine("How many groups do you want to build?");
            int NumberOfGroups = Convert.ToInt16(Console.ReadLine());
            if (NumberOfGroups <= items.Length / 2)
            {
                int PeopleInShortGroup = items.Length / NumberOfGroups;
                int PeopleInLongGroup = items.Length / NumberOfGroups + 1;

                int LongGroups = items.Length % NumberOfGroups;
                int ShortGroups = NumberOfGroups - LongGroups;
                int[] GroupNumberAndIndex = new int[] { 1, 0 };

                PrintGroups(items, GroupNumberAndIndex, LongGroups, PeopleInLongGroup);
                PrintGroups(items, GroupNumberAndIndex, ShortGroups, PeopleInShortGroup);
            }
            else
            {
                Console.WriteLine("Sorry, that's too many groups for this session." +
                	"\nSome people will have to work alone." +
                    "\nChoose a different number.");
                RandomizeUs(items);
            }
        }
            
            
        public static void Main(string[] args)
        {
            string[] AcademySession8 = { "Ellie", "Chris", "Kyle", "Kat", "Taylor", 
                                          "Dasha", "Clarke", "Scott", "Lilith", "Jeff", 
                                            "TJ", "Myles", "Hank", "Hayes", "Stan" };
            RandomizeUs(AcademySession8);
        }
    }
}
