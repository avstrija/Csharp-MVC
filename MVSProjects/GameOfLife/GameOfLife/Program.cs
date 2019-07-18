using System;

namespace GameOfLife
{
    class MainClass
    {
        //This function creates an empty grid;
        public static string[,] CreateGrid(int size)
        {
            string[,] new_grid = new string[size, size];
            Console.WriteLine(size);
            for (int x = 0; x < size; x++)
            {
                for (int i = 0; i < size; i++)
                {
                    new_grid[x, i] = " ";
                }
            }
            return new_grid;
        }

        //Prints the grid to the console;
        public static void ShowField(string[,] grid)
        {
            Console.Write("--------------------------------------\n");
            for (int k = 0; k < Math.Sqrt(grid.Length); k++)
            {
                Console.Write("|");
                for (int i = 0; i < Math.Sqrt(grid.Length); i++)
                {
                    Console.Write("|" + grid[k, i] + "|");
                }
                Console.Write("|\n--------------------------------------\n");
            }
        }
        public static int NeighborCount(string[,] grid, int row, int col) {
            int counter = -1;

            int next_row = (row < (Math.Sqrt(grid.Length) - 1)) ? row + 1 : row;
            int prev_row = (row > 0 ) ? row - 1 : row;
            int prev_col = (col > 0) ? col - 1 : col;
            int next_col = (col < (Math.Sqrt(grid.Length) - 1)) ? col + 1 : col;

            for(int i = prev_row; i <= next_row; ++i) { 
                for(int j = prev_col; j<=next_col; ++j) { 
                    if (grid[i,j]=="X") {
                        ++counter;
                    }
                    if (counter > 3) { break; }
                }
            }
            return counter;
        }
        public static string[,] NextGeneration(string[,] grid) {
            string[,] new_grid = grid;
            for (int k = 0; k < Math.Sqrt(grid.Length); k++)
            {
                for (int i = 0; i < Math.Sqrt(grid.Length); i++)
                {
                    int neighbors = NeighborCount(grid, k, i);
                    //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                    //Any live cell with two or three live neighbours lives on to the next generation.
                    //Any live cell with more than three live neighbours dies, as if by overpopulation.
                    //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    if(grid[k,i] == "X" && (neighbors < 2 || neighbors > 3)) {
                            new_grid[k, i] = " ";
                        }
                    else if(grid[k,i] == " " && neighbors == 2) {
                        new_grid[k, i] = "X";
                    }
                }
            }
            grid = new_grid;
            return grid;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Let's start");
            string[,] new_game = CreateGrid(12);
            new_game[4, 4] = "X";
            new_game[4, 5] = "X";
            new_game[4, 6] = "X";
            new_game[5, 5] = "X";
            new_game[5, 6] = "X";
            new_game[5, 7] = "X";
            new_game[5, 8] = "X";
            new_game[5, 9] = "X";
            new_game[1, 1] = "X";
            Console.WriteLine($"grid length = {new_game.Length}");
            ShowField(new_game);
            bool game_continues = true;
            while(game_continues) {
                Console.WriteLine("Print N to see the next generation, E to Exit");
                string input = Console.ReadLine();
                if(input == "N") {
                    NextGeneration(new_game);
                    ShowField(new_game);
                }
                else if(input == "E") {
                    game_continues = false;
                }
                else {
                    Console.WriteLine("Wrong input. Try again");
                }
            }

        }
    }
}

