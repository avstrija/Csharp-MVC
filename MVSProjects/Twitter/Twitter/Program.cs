using System;
using Mono.Data.Sqlite;

namespace Twitter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection(@"Data Source=/Users/admon/dbs/twitter.sqlite;");
            // test the connection string.
            connection.Open();
            bool keep_going = true;

            while (keep_going)
            {
                Console.WriteLine("What do you want to do? Add tweet (A), print newsfeed(P) or quit (Q)?");

                string whatToDo = Console.ReadLine();
                //Add tweet
                if (whatToDo.ToLower() == "a")
                {
                    Console.WriteLine("What's your ID, user? (Say IDK if you don't know)");
                    string userId = Console.ReadLine();
                    int Id = 0;
                    if (userId == "IDK")
                    {
                        Console.WriteLine("What's your username?");
                        string userName = Console.ReadLine();
                        SqliteCommand userQuery = new SqliteCommand($"SELECT [Id] FROM Users WHERE [UserName] = '{userName}';", connection);

                        SqliteDataReader readerQuery = userQuery.ExecuteReader();
                        if (!readerQuery.HasRows)
                        {
                            SqliteCommand addUser = new SqliteCommand($"INSERT INTO Users (UserName) VALUES ('{userName}');", connection);
                            addUser.ExecuteNonQuery();
                        }
                        if (readerQuery.HasRows)
                        {
                            while (readerQuery.Read())
                            {
                                Console.WriteLine(readerQuery["Id"]);
                                Console.WriteLine($"Here's your ID, {userName}: " + readerQuery["Id"]);
                                Id = Convert.ToInt16(readerQuery["Id"]);
                            }
                        }
                        readerQuery.Close();
                    }
                    else {
                        SqliteCommand IdQuery = new SqliteCommand($"SELECT [Id] FROM Users WHERE [Id] = '{Id}';", connection);
                        SqliteDataReader readQuery = IdQuery.ExecuteReader();

                        if (!readQuery.HasRows)
                        {
                            Console.WriteLine("Wrong ID, try again!");
                            continue;
                        }
                        else {
                            Id = Convert.ToInt16(userId);
                        }
                        readQuery.Close();
                    }

                    Console.WriteLine("What's on your mind?");
                    string tweet = Console.ReadLine();
                    while (tweet.Length > 280)
                    {
                        Console.WriteLine("Tweets cannot be longer than 280 characters. Try again");
                        tweet = Console.ReadLine();
                    }
                    string now = Convert.ToString(DateTime.Now);
                    SqliteCommand addTweet = new SqliteCommand($"INSERT INTO Tweets (Tweet, TimeStamp, UserId) VALUES ('{tweet}', '{now}', '{Id}');", connection);
                    addTweet.ExecuteNonQuery();

                }

                else if (whatToDo.ToLower() == "p")
                {
                    SqliteCommand print = new SqliteCommand("SELECT * FROM Tweets JOIN Users ON Tweets.UserId = Users.Id ORDER BY TimeStamp DESC;", connection);
                    SqliteDataReader reader = print.ExecuteReader();

                    Console.WriteLine("This is your newsfeed!");
                    while (reader.Read())
                    {

                        Console.WriteLine(reader["Tweet"] + " " + reader["TimeStamp"] + " " + reader["UserName"]);
                    }
                    reader.Close();
                }

                else if (whatToDo.ToLower() == "q")
                {
                    keep_going = false;
                }
            }
            connection.Close();
        }
    }
}
