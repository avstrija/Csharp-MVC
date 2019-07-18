using System;
using Mono.Data.Sqlite;

namespace AlbumDB
{
    class MainClass
    {
        public static void AddAlbum(SqliteConnection connection) 
        {
            Console.WriteLine("Please type the artist's name, album title and year separated by commas.");
            string input = Console.ReadLine();
            string[] new_alb = input.Split(',');
            int albumId = 0;

            SqliteCommand addAlbum = new SqliteCommand($"INSERT INTO Albums (Artist, Title, Year) VALUES ('{new_alb[0]}', '{new_alb[1]}', '{new_alb[2]}'); SELECT last_insert_rowid() AS ID", connection);
            SqliteDataReader readerQuery = addAlbum.ExecuteReader();
            if (readerQuery.HasRows)
            {
                albumId = Convert.ToInt16(readerQuery["Id"]);
            }
            readerQuery.Close();

            Console.WriteLine("Album added.");
            AddTracks(connection, albumId);
        }

        public static int FindAlbum(SqliteConnection connection)
        {
            Console.WriteLine("What's the album title?");
            string input = Console.ReadLine();
            string[] split_by_apostrophe = input.Split('\'');
            input = string.Join("''", split_by_apostrophe);

            SqliteCommand getId = new SqliteCommand($"SELECT * FROM Albums WHERE Title = '{input}';", connection);
            SqliteDataReader Idreader = getId.ExecuteReader();
            int albumId = 0;
            if (Idreader.HasRows)
            {
                albumId = Convert.ToInt16(Idreader["Id"]);
                Console.WriteLine("\n" + Idreader["Artist"] + " / " + Idreader["Title"] + " / " + Idreader["Year"] + "\n");
            }
            else
            {
                Console.WriteLine("Sorry, this album is not in my database. Try again.\n");
                PrintAlbums(connection);
                FindAlbum(connection);
            }
            Idreader.Close();
            return albumId;
        }

        public static void AddTracks(SqliteConnection connection, int albumId) 
        {
            while (true)
            {
                Console.WriteLine("Now add some tracks(Press F to finish)\n");
                Console.WriteLine("Add the track title and length separated by commas");
                string input = Console.ReadLine();
                string[] split_by_apostrophe = input.Split('\'');
                input = string.Join("''", split_by_apostrophe);

                if (input.ToLower() == "f")
                {
                    Console.WriteLine("All set! Bye.");
                    break;
                }
                string[] new_track = input.Split(',');
                SqliteCommand addTrack = new SqliteCommand($"INSERT INTO AllTracks (TrackTitle, Length, AlbumId) VALUES ('{new_track[0]}', '{new_track[1]}', '{albumId}');", connection);
                addTrack.ExecuteNonQuery();
            }
        }

        public static void DisplayTracks(SqliteConnection connection)
        {
            int albumId = FindAlbum(connection);
            SqliteCommand printTracks = new SqliteCommand($"SELECT * FROM AllTracks WHERE AlbumId = {albumId};", connection);
            SqliteDataReader TrackReader = printTracks.ExecuteReader();

            while (TrackReader.Read())
            {
                Console.WriteLine(TrackReader["TrackTitle"] + " | " + TrackReader["Length"]);
            }
            Console.WriteLine();
            TrackReader.Close();
        }

        public static void EditAlbum(SqliteConnection connection)
        {
            int albumId = FindAlbum(connection);

            Console.WriteLine("Press A to add more tracks or C to edit album info.");
            string decision = Console.ReadLine();
            if (decision.ToLower() == "a")
            {
                AddTracks(connection, albumId);
            }
            else if (decision.ToLower() == "c")
            {
                UpdateAlbumInfo(connection, albumId);
            }
            else
            {
                Console.WriteLine("Wrong command. Try again!");
                EditAlbum(connection);
            }
        }

        public static void UpdateAlbumInfo(SqliteConnection connection, int albumId) 
        {
            Console.WriteLine("Press 1 to edit artist, 2 to edit title or 3 to edit year.");
            string choice = Console.ReadLine();
            string to_update = "";

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Who's the new artist?");
                    to_update = "Artist";
                    break;
                case "2":
                    Console.WriteLine("What's the new title?");
                    to_update = "Title";
                    break;
                case "3":
                    Console.WriteLine("What's the new year?");
                    to_update = "Year";
                    break;
                default:
                    Console.WriteLine("Wrong command. Try again!");
                    UpdateAlbumInfo(connection, albumId);
                    break;
            }
            string new_info = Console.ReadLine();
            string[] split_by_apostrophe = new_info.Split('\'');
            new_info = string.Join("''", split_by_apostrophe);

            SqliteCommand updater = new SqliteCommand($"UPDATE Albums SET '{to_update}'='{new_info}' WHERE Id='{albumId}';", connection);
            updater.ExecuteNonQuery();
        }

        public static void PrintAlbums(SqliteConnection connection) 
        {
            SqliteCommand print = new SqliteCommand("SELECT * FROM Albums;", connection);
            SqliteDataReader reader = print.ExecuteReader();
            Console.WriteLine("These are your favorite albums!");

            while (reader.Read())
            {
                Console.WriteLine(reader["Artist"] + " / " + reader["Title"] + " / " + reader["Year"]);
            }
            Console.WriteLine();
            reader.Close();
        }

        public static void Main(string[] args)
        {
            SqliteConnection connection = new SqliteConnection(@"Data Source=/Users/admon/dbs/albums.sqlite;");
            bool keep_going = true;

            while (keep_going)
            {
                connection.Open();
                Console.WriteLine("What do you want to do? Add album (A), print all albums(P)," +
                    "\nprint the tracklist for a selected album (T), edit album (E) or quit (Q)?");

                string whatToDo = Console.ReadLine();
                if (whatToDo.ToLower() == "a")
                {
                    AddAlbum(connection);
                }
                else if (whatToDo.ToLower() == "p")
                {
                    PrintAlbums(connection);
                }
                else if (whatToDo.ToLower() == "t")
                {
                    DisplayTracks(connection);
                }
                else if (whatToDo.ToLower() == "e")
                {
                    EditAlbum(connection);
                }
                else if (whatToDo.ToLower() == "q")
                {
                    keep_going = false;
                }
                else 
                {
                    Console.WriteLine("Wrong command. Try again!");
                    connection.Close();
                    continue;
                }
                connection.Close();
            }
        }
    }
}