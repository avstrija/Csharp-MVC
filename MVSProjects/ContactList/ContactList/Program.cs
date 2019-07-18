using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Classen
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactList MyContacts = new ContactList();
            MyContacts.AddContact();
            MyContacts.PrintContactList();
            //player2.FirstName = "John";
            //player2.LastName = "Lange";
            //Console.WriteLine(player2.FullName());
        }

    }

    public class ContactList {
        private List<Contact> MyList;

        public ContactList() {
            MyList = new List<Contact>();
        }

        public void AddContact()
        {
            Console.WriteLine("What is the contact's first name?");
            string first = Console.ReadLine();
            Console.WriteLine("What is the contact's last name?");
            string last = Console.ReadLine();
            Console.WriteLine("What is the contact's phone number?");
            string number = Console.ReadLine();
            Console.WriteLine("Recorded");
            this.MyList.Add(new Contact(first, last, number));
        }

        public void PrintContactList()
        {
            foreach (Contact person in MyList)
            {
                Console.WriteLine(person.FullName());
            }
        }
    }

    public class Contact
    {
        private string FirstName;
        private string LastName;
        private string PhoneNumber;

        public Contact(string first, string last, string phone) {
            FirstName = first;
            LastName = last;
            PhoneNumber = phone;
        }

        public string FullName()
        {
            return LastName + ", " + FirstName + " tel: " + PhoneNumber;
        }
    }

}