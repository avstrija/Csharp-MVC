using System;
namespace Class501
{
    public class Classes
    {
        public static string[] MessageSaver(string[] messages, int index)
        {
            Console.WriteLine("What do you want to say?");
            string new_message = Console.ReadLine();
            messages[index] = new_message;
            Console.WriteLine("Your message ID is " + (index));
            return messages;
        }
    }
}
