using System.Collections.Generic;

namespace TomAndJerry.Tree
{
    public class Node
    {
        public Node(char value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public char Value { get; set; }

        public IList<Node> Children { get; set; }
    }
}
