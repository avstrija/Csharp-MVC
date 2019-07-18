using System;
using System.Collections.Generic;

namespace albums
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Album RockYou = new Album();
            RockYou.PrintAlbum();
        }

        class Album
        {
            // Album class
            //   data includes - list of tracks, year, artist
            public List<Track> tracks = new List<Track>();
            private string artist;
            private string year;
            private string album_name;

            public Album()
            {
                Console.WriteLine("Who's the artist?");
                artist = Console.ReadLine();
                Console.WriteLine("Please give me the album title");
                album_name = Console.ReadLine();
                Console.WriteLine("What year is the album from?");
                year = Console.ReadLine();
                AddTracks(tracks);
            }
            
            public List<Track> AddTracks(List<Track> some_album) {
                Console.WriteLine("Now enter some tracks. How many are there?");
                string input = Console.ReadLine();
                int counter = Convert.ToInt16(input);
                while(counter>0) {
                    Track song = new Track();
                    some_album.Add(song);
                    --counter;
                }
                Console.WriteLine("Album created");
                return some_album;
            }

            public void PrintAlbum() {
                    Console.WriteLine(artist + "/ " + album_name + "/ " + year);
                    foreach (Track t in tracks) {
                        t.PrintTrack();
                    }
                }// function that outputs the list of tracks by looping over it?
            }

            class Track
            {
                private string title;
                private string length;

                public Track()
                {
                    Console.WriteLine("Add the song title");
                    title = Console.ReadLine();
                    Console.WriteLine("Add the song length");
                    length = Console.ReadLine();
                }


                public void PrintTrack() {
                    Console.WriteLine(title + "/ " + length);
                } // function that prints out a line for track
            }
        }
    }
