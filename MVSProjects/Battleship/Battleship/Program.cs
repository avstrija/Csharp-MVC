using System;

namespace Battleship
{
    class MainClass
    {
        //This function creates an empty grid;
        public static string[,] CreateGrid()
        {
            string[,] new_grid = new string[8, 8];
            for (int x = 0; x < 8; ++x)
            {
                for (int i = 0; i < 8; ++i)
                {
                    new_grid[x, i] = " ";
                }
            }
            return new_grid;
        }
        //Prints the grid to the console;
        public static void ShowField(string[,] grid)
        {
            Console.Write("--------------------------\n");
            for (int k = 0; k < 8; ++k)
            {
                Console.Write("|");
                for (int i = 0; i < 8; ++i)
                {
                    Console.Write("|" + grid[k, i] + "|");
                }
                Console.Write("|\n--------------------------\n");
            }
        }
        //Auxiliary: Marks the sides of a vertical ship, so that others don't touch it and the user knows he's close if he hits it;
        public static string[,] MarkNeighborColumns(string[,] some_grid, int row, int col)
        {

            if (col < 7)
            {
                some_grid[row, (col + 1)] = "/";
            }
            if (col > 0)
            {
                some_grid[row, (col - 1)] = "/";
            }
            return some_grid;
        }
        //Same for horizontal ship;
        public static string[,] MarkNeighborRows(string[,] some_grid, int row, int col)
        {

            if (row < 7)
            {
                some_grid[(row + 1), col] = "/";
            }
            if (row > 0)
            {
                some_grid[(row - 1), col] = "/";
            }
            return some_grid;
        }

        //Builds a horizontal ship;
        public static string[,] BuildVertical(string[,] some_grid, int row, int col, int size)
        {
            some_grid[row, col] = "s";

            int num_cells = 1;
            some_grid = MarkNeighborColumns(some_grid, row, col);

            if (row > 0)
            {
                some_grid[(row - 1), col] = "/";
                some_grid = MarkNeighborColumns(some_grid, (row - 1), col);
            }

            while (num_cells < size)
            {
                ++row;
                some_grid[row, col] = "s";
                ++num_cells;
                some_grid = MarkNeighborColumns(some_grid, row, col);
            }
            if (num_cells == size && row < 7)
            {
                some_grid[(row + 1), col] = "/";
                some_grid = MarkNeighborColumns(some_grid, (row + 1), col);
            }
            return some_grid;
        }
        //Builds a vertical ship;
        public static string[,] BuildHorizontal(string[,] some_grid, int row, int col, int size)
        {
            some_grid[row, col] = "s";

            int num_cells = 1;
            some_grid = MarkNeighborRows(some_grid, row, col);

            if (col > 0)
            {
                some_grid[row, (col - 1)] = "/";
                some_grid = MarkNeighborRows(some_grid, row, (col - 1));
            }
            while (col < 7 && num_cells < size)
            {
                ++col;
                some_grid[row, col] = "s";
                ++num_cells;
                some_grid = MarkNeighborRows(some_grid, row, col);
            }
            if (num_cells == size && col < 7)
            {
                some_grid[row, (col + 1)] = "/";
                some_grid = MarkNeighborRows(some_grid, row, (col + 1));
            }
            return some_grid;
        }

        //Checks if you can build a vertical ship that doesn't touch others starting at a given point;
        public static bool PossibleVertical(string[,] some_grid, int row, int col, int size)
        {
            for (int i = row; i < row + size; ++i)
            {
                if (some_grid[i, col] != " ")
                {
                    return false;
                }
            }
            return true;
        }
        //Checks if you can build a horizontal ship that doesn't touch others starting at a given point;
        public static bool PossibleHorizontal(string[,] some_grid, int row, int col, int size)
        {
            for (int i = col; i < col + size; ++i)
            {
                if (some_grid[row, i] != " ")
                {
                    return false;
                }
            }
            return true;
        }

        //Creates a ship of a given size at a random spot;
        public static string[,] ShipCreator(string[,] some_grid, int size)
        {
            Random r = new Random();
            int direction = r.Next(0, 2);//0 - vertical, 1 - horizontal
            //Console.WriteLine(direction);
            int row_1 = 0;
            int col_1 = 0;

            if (direction == 0)
            {
                row_1 = r.Next(0, (9 - size));
                col_1 = r.Next(0, 8);
                if (!PossibleVertical(some_grid, row_1, col_1, size))
                {
                    ShipCreator(some_grid, size);
                }
                else
                {
                    return BuildVertical(some_grid, row_1, col_1, size);
                }
            }

            else if (direction == 1)
            {
                row_1 = r.Next(0, 8);
                col_1 = r.Next(0, (9 - size));
                if (!PossibleHorizontal(some_grid, row_1, col_1, size))
                {
                    ShipCreator(some_grid, size);

                }
                else
                {
                    return BuildHorizontal(some_grid, row_1, col_1, size);
                }
            }
            return some_grid;
        }

        //Calls the Ship Creator for 5 ships of different size;
        public static string[,] CreateShips(string[,] my_grid)
        {
            //Carrier (occupies 5 spaces)
            ShipCreator(my_grid, 5);

            //Battleship(4)
            ShipCreator(my_grid, 4);

            //Submarine (3)
            ShipCreator(my_grid, 3);

            //Cruiser(3)
            ShipCreator(my_grid, 3);

            //Destroyer(2).
            ShipCreator(my_grid, 2);

            return my_grid;
        }

        //MAIN FUNCTION

        public static void Main(string[] args)
        {

            string[,] my_grid = CreateGrid();
            my_grid = CreateShips(my_grid);

            ShowField(my_grid);
                

            string[,] user_grid = CreateGrid();


            Console.WriteLine("Let's start! Here's the misty battlefield. \n" +
                "There are 5 ships hidden here: Carrier (occupies 5 spaces), Battleship (4)," +
                "\nCruiser (3), Submarine (3), and Destroyer (2).");

            ShowField(user_grid);
            bool game_running = false;
            for (int i = 0; i < 8; ++i)
            {
                for (int x = 0; x < 8; ++x)
                {
                    if (my_grid[i, x] == "s")
                    {
                        game_running = true;
                        break;
                    }
                }
            }


            while (game_running)
            {
                Console.WriteLine("Shoot! First, pick a row: ");
                string input1 = Console.ReadLine();
                Console.WriteLine("Shoot! First, pick a column: ");
                string input2 = Console.ReadLine();
                int row = Convert.ToInt16(input1) - 1;
                int column = Convert.ToInt16(input2) - 1;

                if (my_grid[row, column] == "s")
                {
                    Console.WriteLine("It's a hit!\n");
                    user_grid[row, column] = "h";
                    my_grid[row, column] = "x";

                }
                else if (my_grid[row, column] == " " || my_grid[row, column] == "/")
                {
                    if (my_grid[row, column] == "/")
                    {
                        Console.WriteLine("Close! Try again!\n");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you missed. Try again!\n");
                    }
                    user_grid[row, column] = "-";
                }
                else if (my_grid[row, column] == "x")
                {
                    Console.WriteLine("You already hit a ship at this spot. Try again!\n");
                }
                ShowField(user_grid);
                Console.WriteLine("");
                //ShowField(my_grid);
            }
            Console.WriteLine("Hooray! You won!");
        }
    }
}

