﻿using System;

namespace AVLTree
{
    public class Startup
    {
        public static void Main()
        {
            var tree = new AVL();

            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            //tree.Add(7);
            //tree.Add(8);
            //tree.Add(9);
            //tree.Add(10);
            //tree.Add(11);
            //tree.Add(12);


            //Console.WriteLine(tree.Exists(12));

            tree.Remove(6);
            tree.Remove(5);

            tree.Print();
        }
    }
}
