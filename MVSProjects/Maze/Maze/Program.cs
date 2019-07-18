using NUnit.Framework;
using System.Linq;
using System;

public class Finder
{

    public static char[][] CreateField(string maze)
    {
        string[] maze_lines = maze.Split(Environment.NewLine.ToCharArray());
        char[][] my_maze = new char[maze_lines.Length][];
        int index = 0;
        foreach (string s in maze_lines)
        {
            char[] chars = new char[maze_lines.Length];
            for (int i = 0; i < s.Length; ++i)
            {
                chars[i] = s[i];
            }
            my_maze[index] = chars;
            ++index;
        }
        return my_maze;
    }


    public static char[][] PathMarker(char[][] maze, int row, int col)
    {
        if (maze[row][col] == '+')
        {
            maze[row][col] = 'W';
        }
        else
        {
            maze[row][col] = '+';
        }
        return maze;
    }

    public static bool PathFinder(string maze)
    {
        char[][] my_maze = CreateField(maze);
        int row = 0;
        int col = 0;
        bool PossibleSouth = true;
        bool PossibleEast = true;

        while (row != (my_maze.Length - 1) || col != (my_maze.Length - 1))
        {
            PossibleSouth = row < (my_maze.Length - 1) && (my_maze[row + 1][col] != 'W');
            PossibleEast = col < (my_maze.Length - 1) && (my_maze[row][col + 1] != 'W');

            //Step South;
            if (PossibleSouth)
            {
                Console.WriteLine("South " + row + " " + col + " " + my_maze[row][col]);
                PathMarker(my_maze, row, col);
                ++row;
            }
            //Step East;
            else if (PossibleEast)
            {
                //Console.WriteLine("Not possible south");
                Console.WriteLine("EAST " + row + " " + col + " " + my_maze[row][col]);
                PathMarker(my_maze, row, col);
                ++col;
            }
            //Return North;
            else if (row > 0 && my_maze[row - 1][col] != 'W')
            {

                while (row > 0 && my_maze[row - 1][col] != 'W')
                {
                    Console.WriteLine("North " + row + " " + col + " " + my_maze[row][col]);
                    //PathMarker(my_maze, row, col);
                    --row;
                    PossibleEast = col < (my_maze.Length - 1) && (my_maze[row][col + 1] != 'W');
                    if (PossibleEast)
                    {
                        Console.WriteLine("Second step east " + row + " " + col + " " + my_maze[row][col]);
                        PathMarker(my_maze, row, col);
                        break;
                    }
                }

            }
            //Step back West;
            else if (col > 0 && my_maze[row][col - 1] != 'W')
            {
                while (col > 0 && my_maze[row][col - 1] != 'W')
                {
                    Console.WriteLine("West " + row + " " + col + " " + my_maze[row][col]);
                    //PathMarker(my_maze, row, col);
                    --col;
                    PossibleSouth = row < (my_maze.Length - 1) && (my_maze[row + 1][col] != 'W');
                    if (PossibleSouth)
                    {
                        Console.WriteLine("Second step South " + row + " " + col + " " + my_maze[row][col]);
                        PathMarker(my_maze, row, col);
                        ++row;
                        break;
                    }
                }


            }
            else
            //if (row < (my_maze.Length-1) && my_maze[row+1][col] == 'W' && col < (maze.Length-1) && my_maze[row][col+1] == 'W') 
            {
                foreach (var s in my_maze)
                {
                    foreach (var c in s)
                    {
                        Console.Write(c);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("FINISH " + row + " " + col + " " + my_maze[row][col]);
                return false;
            }
        }
        Console.WriteLine("Hooray!");
        return true;
    }
}