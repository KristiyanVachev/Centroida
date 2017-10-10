using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TomAndJerry.Tree;

namespace TomAndJerry
{
    public class TomController
    {
        public TomController()
        {
            this.Paths = new List<Path>();
            this.ShortestLenght = int.MaxValue;
            this.ShortestPaths = new Tree.Tree();
        }

        public IList<Path> Paths { get; set; }

        public int ShortestLenght { get; set; }

        public Tree.Tree ShortestPaths { get; set; }
    
        //Tree
        public void Add(Path path)
        {
            this.Paths.Add(path);

            if (this.ShortestLenght > path.Lenght)
            {
                this.ShortestLenght = path.Lenght;
            }
        }

        public void ConstructTree()
        {
            foreach (var path in Paths)
            {
                if (path.Lenght == this.ShortestLenght)
                {
                    this.ShortestPaths.AddPath(path);
                }
            }
        }

        public void Manual()
        {
            //No paths
            if (!this.ShortestPaths.Root.Children.Any())
            {
                Console.WriteLine("No paths available");
                return;
            }

            var currentNode = this.ShortestPaths.Root;

            while (currentNode.Children.Any())
            {
                if (currentNode.IsPaint)
                {
                    Console.WriteLine("Throw some paint");
                }

                Console.Write("Choose path from: ");
                foreach (var child in currentNode.Children)
                {
                    Console.Write(child.Direction + " ");
                }
                Console.WriteLine();

                Node newNode = null;
                while (newNode == null)
                {
                    var input = Console.ReadLine();
                    newNode = currentNode.Children.FirstOrDefault(x => x.Direction.ToString() == input);

                    if (newNode == null)
                    {
                        Console.WriteLine("Invalid choice, try again");
                    }
                }

                currentNode = newNode;
            }

            Console.WriteLine("Congratulations, you've killed Jerry!");
            Thread.Sleep(2000);
            Console.WriteLine("Ooops, wasn't I suppose to do that?");
            Thread.Sleep(1000);
            Console.WriteLine("Sorry");
            Thread.Sleep(1000);
            Console.WriteLine("Gotta go!");
            Thread.Sleep(1000);

            Console.Write("Deleting all files");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine();

            Console.WriteLine("Sorry!");
        }
    }
}
