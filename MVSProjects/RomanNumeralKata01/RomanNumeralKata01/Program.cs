using System;

namespace RomanNumeralKata01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Enter your number to be converted: ");
            input = Console.ReadLine();
            int userInt = Convert.ToInt32(input);

            string result = ConvertToRoman(userInt);
            Console.WriteLine(input + " written in Roman Numerals is " + result);
            Console.ReadLine();
        }

        static string ConvertToRoman(int number)
        {
            string roman = "";
            while (number >= 1000) {
                number = number - 1000;
                roman = roman + "M";
            }

            if (number >= 900)
            {
                number = number - 900;
                roman = roman + "CM";
            }

            if (number >= 500)
            {
                number = number - 500;
                roman = roman + "D";
            }

            if (number >= 400)
            {
                number = number - 400;
                roman = roman + "CD";
            }

            while (number >= 100) {
                number = number - 100;
                roman = roman + "C";
            }
            if (number >= 90) {
                number = number - 90;
                roman = roman + "XC";
            }
            if (number >= 50)
            {
                number = number - 50;
                roman = roman + "L";
            }
            if (number >= 40)
            {
                number = number - 40;
                roman = roman + "XL";
            }
            while (number >= 10)
            {
                number = number - 10;
                roman = roman + "X";
            }
            if (number >= 9)
            {
                number = number - 90;
                roman = roman + "IX";
            }
            if (number >= 5)
            {
                number = number - 5;
                roman = roman + "V";
            }
            if (number >= 4)
            {
                number = number - 4;
                roman = roman + "IV";
            }
            while (number >= 1)
            {
                number = number - 1;
                roman = roman + "I";
            }
            return roman;
        }
    }
}
