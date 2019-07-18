using System;

namespace Numbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            String[][] month_names = new string[12][];
            month_names[0] = new string[] { "01", "1", "jan", "january" };
            month_names[1] = new string[] { "02", "2", "feb", "february" };
            month_names[2] = new string[] { "03", "3", "mar", "march" };
            month_names[3] = new string[] { "april", "04", "4", "apr" };
            month_names[4] = new string[] { "may", "05", "5", "may" };
            month_names[5] = new string[] { "june", "06", "6", "jun" };
            month_names[6] = new string[] { "july", "07", "7", "jul" };
            month_names[7] = new string[] { "august", "08", "8", "aug" };
            month_names[8] = new string[] { "september", "09", "9", "sep" };
            month_names[9] = new string[] { "october", "10", "oct" };
            month_names[10] = new string[] { "november", "11", "nov" };
            month_names[11] = new string[] { "december", "12", "dec" };



            //Input Season
            string input_month = "Start";
            while (input_month != "Finish") {
                Console.WriteLine("What month were you born in?");
                input_month = Console.ReadLine().ToLower();

                int[] strange_months = { 2, 5, 8, 11 };
                bool correct = false;
                bool weird = false;
                int month_index = 13;
                foreach (string[] str in month_names) {
                    correct = Array.Exists(str, element => element == input_month);
                    if (correct) {
                        month_index = Array.IndexOf(month_names, str);
                        weird = Array.Exists(strange_months, element => element == month_index);
                        break;
                    }
                }


                if (!correct)
                {
                        Console.WriteLine("Such month doesn't exist.");
                    }
                else {
                    if (weird)
                    {
                        Console.WriteLine("Enter the day you were born on: ");
                        string input_day = Console.ReadLine();
                        int day = Convert.ToInt16(input_day);
                        while (day < 1 || day > 31)
                        {
                            Console.WriteLine("Wrong day! Try again");
                            input_day = Console.ReadLine();
                            day = Convert.ToInt16(input_day);
                        }

                        if (month_index == 2 && day >= 20)
                        {
                            month_index += 1;
                        }
                        else if (month_index == 5 && day >= 21)
                        {
                            month_index += 1;
                        }
                        else if (month_index == 8 && day >= 23)
                        {
                            month_index += 1;
                        }
                        else if (month_index == 11 && day >= 22)
                        {
                            month_index = 0;
                        }
                        else
                        {
                            month_index -= 1;
                        }

                    }
                    string season;

                    if (month_index == 0 || month_index == 1)
                    {
                        season = "winter.";
                    }
                    else if (month_index == 3 || month_index == 4)
                    {
                        season = "spring.";
                    }
                    else if (month_index == 6 || month_index == 7)
                    {
                        season = "summer.";
                    }
                    else if (month_index == 9 || month_index == 10)
                    {
                        season = "fall.";
                    }
                    else {
                        season = "...who knows.";
                    }
                    Console.WriteLine("You were born in " + season);
                }// the big else
            }
        }
    }
}