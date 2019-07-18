using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class501
{
    class MainClass
    {
        public static string MessageEncrypter(string old_message) {
            string new_message = "";
            string new_char = "x";
            int value = 0;
            foreach (char c in old_message) {
                value = (int)c + 13;
                new_char = Convert.ToString((char)value);
                new_message += new_char;
            }
            return new_message;
        }

        public static string MessageDecrypter(string old_message)
        {
            string new_message = "";
            string new_char = "x";
            int value = 0;
            foreach (char c in old_message)
            {
                value = (int)c - 13;
                new_char = Convert.ToString((char)value);
                new_message += new_char;
            }
            return new_message;
        }

        public static string[] MessageSaver(string[] messages, int index)
        {
            Console.WriteLine("What do you want to say?");
            string new_message = Console.ReadLine();
            messages[index] = MessageEncrypter(new_message);
            Console.WriteLine("Your message ID is " + (index));
            return messages;
        }

        public static void MessageRetriever(string[] messages) 
        {
            Console.WriteLine("What's the ID of the message you want to read?");
            string new_ID = Console.ReadLine();
            int ID = Convert.ToInt16(new_ID);
            if (messages[ID] != null || ID < 0 || ID > messages.Length)
            {
                Console.WriteLine("The message is: " + MessageDecrypter(messages[ID]));
            }
            else
            {
                Console.WriteLine("Sorry, wrong ID. Try again.");
            }
        }

        public static void PrintEncrypted(string[] messages) { 
            foreach (string s in messages) {
                Console.WriteLine(s);
            }
        }

        public static void Main(string[] args)
        {
            string[] messages = new string[2];
            int index = 0;
            while (true)
            {
                Console.WriteLine("What do you want to do?\n(Press ? to see the commands)");
                string input = Console.ReadLine().ToUpper();
                if (input == "?") {
                    Console.WriteLine(
                        "S - Save a new message\n" +
                        "R - Retrieve a message\n" +
                        "D - Delete a message\n" +
                        "E - Exit\n" +
                        "P - Print encrypted messages"
                        );
                    input = Console.ReadLine().ToUpper();
                }
                if (input == "S")
                {
                    if (index > (messages.Length - 1))
                    {
                        Array.Resize(ref messages, index + 2);
                    }
                    while (messages[index] != null) {
                        ++index;
                    }
                    MessageSaver(messages, index);
                    ++index;

                }
                else if(input == "D") {
                    Console.WriteLine("What's the ID of the message you want to delete?");
                    string new_ID = Console.ReadLine();
                    int ID = Convert.ToInt16(new_ID);
                    messages[ID] = null;
                    index = ID;
                }
                else if (input == "R")
                {
                    MessageRetriever(messages);
                }
                else if (input == "P")
                {
                    PrintEncrypted(messages);
                }
                else if (input == "E") {
                    Console.WriteLine("Bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again");
                }
            }
        }
    }
}
