using System;
using System.Linq;

namespace MorseCode
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz ";
            string[] morse = {
".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--",
"-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "   "
};

            Console.WriteLine("What message should I translate to Morse code?");
            string message = Console.ReadLine().ToLower();
            string morse_text = "";

            foreach (char c in message) {
                if (Char.IsLetter(c) || c == ' ')
                morse_text += morse[alphabet.IndexOf(c)] + " ";
            }
            Console.WriteLine("Your message in Morse: " + morse_text);
        }
    }
}
    