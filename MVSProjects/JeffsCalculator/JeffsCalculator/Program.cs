using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            while (!end)
            {
                string userInput = Console.ReadLine();

                //Creating empty List
                List<double> nums = new List<double>();

                //Splitting the input by '+' and '-';
                string[] operands_secondary = userInput.Split(new char[] { '+', '-' });

                //Performing primary operations && filling the list of nums for secondary operations
                foreach (string item in operands_secondary)
                {
                    double d;
                    //Handling primary operations;
                    if (item.Contains("%") || item.Contains("/") || item.Contains("*"))
                    {
                        List<double> primary_nums = new List<double>();
                        //Parsing the numbers;
                        string[] operands_primary = item.Split(new char[] { '%', '/', '*' });

                        foreach (var s in operands_primary)
                        {
                            double.TryParse(s, out d);
                            primary_nums.Add(d);
                        }
                        //CALCULATION_1 left -> right
                        int i = 0;
                        foreach (char c in item)
                        {
                            if (c == ('%') || c == ('/') || c == ('*'))
                            {
                                switch (c)
                                {
                                    case '/':
                                        if (primary_nums[i + 1] == 0) { end = true; }
                                        else { primary_nums[i + 1] = primary_nums[i] / primary_nums[i + 1]; }
                                        break;
                                    case '*':
                                        primary_nums[i + 1] *= primary_nums[i];
                                        break;
                                    case '%':
                                        primary_nums[i + 1] = primary_nums[i] % primary_nums[i + 1];
                                        break;
                                }
                                ++i;
                            }
                        }
                        d = primary_nums[primary_nums.Count - 1];
                    }
                    else { double.TryParse(item, out d); }
                    //Adding the result of multiplication/division OR the new_number to the final list;
                    nums.Add(d);
                }

                if(end) { 
                    Console.WriteLine("Cannot divide by zero");
                    break;
                }

                //CALCULATION_2 left -> right
                int j = 0;
                foreach (char c in userInput)
                {
                    if (c == ('+') || c == ('-'))
                    {
                        switch (c)
                        {
                            case '+':
                                nums[j + 1] += nums[j];
                                break;
                            case '-':
                                nums[j + 1] = nums[j] - nums[j + 1];
                                break;
                        }
                        ++j;
                    }
                }
                Console.WriteLine(userInput + " = " + nums[nums.Count - 1]);
            }
        }
    }
}