using System;
using System.Collections.Generic;
using System.Linq;

namespace Module2Ex2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentence:");
            string s = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter a letter:");
            Console.WriteLine("Your letter usage is as follows:");
            s = s.Replace(" ", string.Empty);
            string used_letters = "";
            var counters = new List<Tuple<int, string>>();
            foreach (char c in s)
            {
                int counter = 1;
                string l = Convert.ToString(c);
                if (used_letters.Contains(l))
                {
                    continue;
                }
                else
                {
                    for (int k = s.IndexOf(c) + 1; k < s.Length; ++k)
                    {
                        if (s[k] == c)
                        {
                            ++counter;
                            used_letters += c;
                        }
                    }
                    counters.Add(new Tuple<int, string> (counter, l));
                }
            }
            var result = counters.OrderByDescending(a => a.Item1);
            foreach (var item in result)
            {
                Console.WriteLine(item.Item1 + ": " + item.Item2);
            }
        }
    }
}

