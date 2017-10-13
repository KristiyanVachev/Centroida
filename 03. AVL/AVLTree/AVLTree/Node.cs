using System;

namespace AVLTree
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Node Parent { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("/-");
                indent += "| ";
            }
            Console.WriteLine(this.Value);

            Right?.PrintPretty(indent, true);
            Left?.PrintPretty(indent, false);
        }
    }
}
