using System.Collections.Generic;

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
    }
}
