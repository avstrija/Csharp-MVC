using System;
using Mono.Data.Sqlite;

namespace RolodexAccessor
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // for DBS:
            // * connection - where the request goes
            // * command - what request we are making
            // * reader - reading the response.

            // 1. connection
            SqliteConnection myConnection;
            // tell it where the db is
            // connection string is probably your #1 issue for the first 3 problems. Once you've got it working, you're cool.
            // with sqlite, if you get the name wrong, it'll just create a new blank db for you.
            myConnection = new SqliteConnection(@"Data Source=/Users/admon/dbs/my_db.sqlite;");
            // test the connection string.
            myConnection.Open();

            //promt
            Console.WriteLine("Do you want to add a user (A) or see the users (P)?");
            string action = Console.ReadLine();
            if (action.ToLower()=="a") {
                Console.WriteLine("Please add name, phone number, city, state, and post code separated by commas");
                string unsplit = Console.ReadLine();
                string[] user = unsplit.Split(',');
                string sql = "INSERT INTO Rolodex" + 
                    "(Name, 'Phone Number', City, State, 'Post Code') " +
                    "VALUES ('{user[0]}', '{user[1]}', '{user[2]}', '{user[3]}', '{user[4]}');";
                SqliteCommand insert = new SqliteCommand(sql, myConnection);

            }
            else if (action.ToLower() == "p") {
                SqliteCommand command = new SqliteCommand("SELECT * FROM Rolodex;", myConnection);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
                Console.WriteLine("  - Phone Number: " + reader["Phone Number"]);
                Console.WriteLine("  - City: " + reader["City"] + ", " + reader["State"] + ", " + reader["Post Code"]);
            }
                reader.Close();
            }
            else {
                Console.WriteLine("Wrong command, try again");

            }

            myConnection.Close();
        }
    }
}

