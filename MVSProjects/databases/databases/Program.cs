using System;
using Mono.Data.Sqlite;


namespace databases
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SqliteConnection myConnection = new SqliteConnection(@"Data Source=/Users/admon/dbs/my_db.sqlite;");
            myConnection.Open();

            SqliteCommand insert = new SqliteCommand("INSERT INTO Rolodex (Name, 'Phone Number', City, ID) VALUES ('C# added me', '12345', 'Pittsburgh', 3);", myConnection);

            SqliteDataReader readerInsert = insert.ExecuteReader();
            if(readerInsert.HasRows) 
            {
                Console.WriteLine("Hey, we got back rows!");
            }
            else 
            {
                Console.WriteLine("no rows.");
            }

            SqliteCommand command = new SqliteCommand("SELECT * FROM Rolodex WHERE city='Pittsburgh';", myConnection);

            SqliteDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader["Name"]);
                Console.WriteLine(reader["Phone Number"]);
                Console.WriteLine(reader["Post Code"]);
                Console.WriteLine(reader["Address Line 1"]);
            }

            myConnection.Close();
        }
    }
}
