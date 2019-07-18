using System;

namespace TextTemplates
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            string template = "The title is [title] and the body of the text is: [body]\n\nWritten by: [author] Date: [date]";

            string[] TemplateArray = template.Split(new char[] { '[', ']' });

            for (int i = 1; i < TemplateArray.Length; i = i + 2)
            {
                Console.WriteLine($"Please enter a {TemplateArray[i]}:");
                TemplateArray[i] = Console.ReadLine();
            }

            Console.WriteLine(String.Concat(TemplateArray));
        }
    }
}
