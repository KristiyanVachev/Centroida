using System.Linq;

namespace TomAndJerry.Tree
{
    public class Tree
    {
        public Tree()
        {
            this.Root = new Node(' ', false);
        }

        public Node Root { get; set; }

        public void AddPath(Path path)
        {
            var currentNode = this.Root;

            foreach (var command in path.Commands)
            {
                var found = currentNode.Children.FirstOrDefault(x => x.Direction == command.Direction);

                if (found == null)
                {
                    var newNode = new Node(command.Direction, command.IsPaint);
                    currentNode.Children.Add(newNode);
                    currentNode = newNode;
                }
                else
                {
                    currentNode = found;
                }
            }
        }
    }
}
