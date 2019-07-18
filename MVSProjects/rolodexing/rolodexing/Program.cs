using System;
using Mono.Data.Sqlite;

namespace rolodexing
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection(@"Data Source=/Users/admon/dbs/rolodex.sqlite;");
            // test the connection string.
            connection.Open();

            SqliteCommand command = new SqliteCommand("SELECT * FROM Movies;", connection);
            SqliteDataReader reader = command.ExecuteReader();

            Console.WriteLine("All my movies!");
            while (reader.Read())
            {
                Console.WriteLine(reader["Title"]);
            }

            Console.WriteLine(DateTime.Now);

            reader.Close();
            connection.Close();
        }
    }
}
