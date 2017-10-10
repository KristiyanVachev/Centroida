using System.Configuration;

namespace AVLTree
{
    public class AVL
    {
        public Node Root { get; set; }

        public void Add(int value)
        {
            var newNode = new Node(value);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                //Insert node
                var currNode = this.Root;

                while (currNode != null)
                {
                    var prevNode = currNode;

                    if (newNode.Value < currNode.Value)
                    {
                        currNode = currNode.Left;

                        if (currNode == null)
                        {
                            prevNode.Left = newNode;
                            newNode.Parent = prevNode;
                        }
                    }
                    else
                    {
                        currNode = currNode.Right;

                        if (currNode == null)
                        {
                            prevNode.Right = newNode;
                            newNode.Parent = prevNode;
                        }
                    }
                }
            }

            if (newNode.Value == 8)
            {
                NeedsBalance(newNode);
            }
        }

        private bool NeedsBalance(Node node)
        {
            if (node.Parent == null || node.Parent.Parent == null)
            {
                return false;
            }

            if ((node.Parent.Left == null || node.Parent.Right == null) && (node.Parent.Parent.Left == null || node.Parent.Parent.Right == null))
            {
                this.Balance(node);
                return true;
            }

            return false;
        }

        private void Balance(Node node)
        {
            if (node.Parent.Left == null && node.Parent.Parent.Left == null)
            {
                LeftRotation(node);
            }


        }

        private void LeftRotation(Node node)
        {
            var middle = node.Parent;
            var top = node.Parent.Parent;

            if (top.Parent != null)
            {
                top.Parent.Right = middle;
            }
            else
            {
                this.Root = middle;
            }

            middle.Left = top;
            middle.Parent = top.Parent;
            top.Parent = middle;
        }
    }
}
