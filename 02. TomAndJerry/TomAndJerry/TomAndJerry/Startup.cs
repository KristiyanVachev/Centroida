using System;
using System.Collections.Generic;
using System.Linq;

namespace TomAndJerry
{
    public class Startup
    {
        public static void Main()
        {
            //m = 4;
            //n = 4;
            //jerry = 0,2
            //tom = 3,0
            //furniture count - 2
            //paint count - 1
            //furniture - 2,1 - 11/01
            //furniture - 1,3 - 1
            //paint - 1,1

            var floor = new[,]
            {
                {' ', ' ', 'J', ' '},
                {' ', 'P', 'F', 'F'},
                {' ', ' ', ' ', 'F'},
                {'T', 'F', ' ', ' '}
            };

            var paths = GatherPaths(0, 3, floor);

            foreach (var path in paths)
            {
                for (int index = 0; index < path.Count; index++)
                {
                    Console.Write(index);
                }
                Console.WriteLine();
            }

        }

        public static List<List<char>> GatherPaths(int tomRow, int tomCol, char[,] floor)
        {
            //save all paths somewhere
            var foundPaths = new List<List<char>>();
            var currentPath = new List<char>();

            Path(tomRow, tomCol, 'F', floor, foundPaths, currentPath);
            //explore each direction

            return foundPaths;
        }

        public static void Path(int row, int col, char dir, char[,] floor, List<List<char>> foundPaths, List<char> currentPath)
        {
            //Check if dir is walkable
            if (!PathIsValid(row, col, dir, floor))
            {
                return;
            }

            //copy currentPath and add new direction
            var newPath = currentPath.ToList();
            newPath.Add(dir);

            //Get new coordinates
            switch (dir)
            {
                case 'F':
                    row--;
                    break;
                case 'B':
                    row++;
                    break;
                case 'L':
                    col--;
                    break;
                case 'R':
                    col++;
                    break;
            }

            //if Jerry add to directions and stop
            if (floor[row, col] == 'J')
            {
                foundPaths.Add(newPath);
            }

            //mark as walked with X
            floor[row, col] = 'X';

            //explore others
            Path(row, col, 'F', floor, foundPaths, newPath);
            Path(row, col, 'B', floor, foundPaths, newPath);
            Path(row, col, 'L', floor, foundPaths, newPath);
            Path(row, col, 'R', floor, foundPaths, newPath);
        }

        public static bool PathIsValid(int row, int col, char dir, char[,] floor)
        {
            switch (dir)
            {
                case 'F':
                    if (row <= 0 || floor[row - 1, col] == 'F' || floor[row - 1, col] == 'X')
                    {
                        return false;
                    }

                    break;

                case 'B':
                    if (row >= floor.GetLength(0) - 1 || floor[row + 1, col] == 'F' || floor[row + 1, col] == 'X')
                    {
                        return false;
                    }
                    break;

                case 'L':
                    if (col <= 0 || floor[row, col - 1] == 'F' || floor[row, col - 1] == 'X')
                    {
                        return false;
                    }
                    break;

                case 'R':
                    if (col >= floor.GetLength(1) - 1 || floor[row, col + 1] == 'F' || floor[row, col + 1] == 'X')
                    {
                        return false;
                    }
                    break;

                default:
                    return false;
            }

            return true;
        }

        //TODO Lenght of shortest path from Tom to Jerry
        //TODO All shortest paths from Tom to Jerry
        //TODO How much paint from every path
        //TODO How much turns from every path
        //TODO All commands
        //TODO Tree of shortest paths
    }
}
