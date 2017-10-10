using System;
using System.Collections.Generic;

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

            var paths = GatherPaths(3, 0, floor);

            //Print
            foreach (var path in paths)
            {
                for (int index = 0; index < path.Commands.Count; index++)
                {
                    Console.Write(path.Commands[index].Direction);
                }
                Console.WriteLine();
            }

        }

        public static IList<Path> GatherPaths(int tomRow, int tomCol, char[,] floor)
        {
            //save all paths somewhere
            var foundPaths = new List<Path>();
            var currentPath = new Path();

            Path(tomRow, tomCol, 'F', floor, foundPaths, currentPath);
            Path(tomRow, tomCol, 'B', floor, foundPaths, currentPath);
            Path(tomRow, tomCol, 'L', floor, foundPaths, currentPath);
            Path(tomRow, tomCol, 'R', floor, foundPaths, currentPath);
    
            return foundPaths;
        }

        public static void Path(int row, int col, char dir, char[,] floor, IList<Path> foundPaths, Path currentPath)
        {
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

            if (!PathIsValid(row, col, floor, currentPath))
            {
                return;
            }

            //Create a copy of the path until now (each of 4 directions creates a new path)
            var newPath = currentPath.Copy();
            newPath.Add(row, col, dir, floor[row, col]);

            //if Jerry add to directions and stop
            if (floor[row, col] == 'J')
            {
                foundPaths.Add(newPath);
                return;
            }

            //Explore
            Path(row, col, 'F', floor, foundPaths, newPath);
            Path(row, col, 'B', floor, foundPaths, newPath);
            Path(row, col, 'L', floor, foundPaths, newPath);
            Path(row, col, 'R', floor, foundPaths, newPath);
        }

        public static bool PathIsValid(int row, int col, char[,] floor, Path currentPath)
        {
            //Out of matrix
            if (row < 0 || row > floor.GetLength(0) - 1 || col < 0 || col > floor.GetLength(1) - 1)
            {
                return false;
            }

            //Furniture
            if (floor[row, col] == 'F')
            {
                return false;
            }

            //Already walked trough
            if (currentPath.Walked(row, col))
            {
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
