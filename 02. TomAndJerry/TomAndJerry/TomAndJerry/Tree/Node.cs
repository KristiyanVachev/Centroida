using System.Collections.Generic;

namespace TomAndJerry.Tree
{
    public class Node
    {
        public Node(char direction, bool isPaint)
        {
            this.Direction = direction;
            this.IsPaint = isPaint;
            this.Children = new List<Node>();
        }

        public char Direction { get; set; }

        public bool IsPaint { get; set; }

        public IList<Node> Children { get; set; }
    }
}
