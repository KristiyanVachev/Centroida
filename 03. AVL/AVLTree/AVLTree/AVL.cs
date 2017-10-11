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

            if (NeedsBalance(newNode))
            {
                this.Balance(newNode);
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
                return true;
            }

            return false;
        }

        private void Balance(Node node)
        {
            if (node.Parent.Left == null && node.Parent.Parent.Left == null)
            {
                LeftRotation(node.Parent);
            }
            else if (node.Parent.Right == null && node.Parent.Parent.Right == null)
            {
                RightRotation(node.Parent);
            }
            else if (node.Parent.Left == null && node.Parent.Parent.Right == null)
            {
                LeftRightRotation(node);
            }
            else if (node.Parent.Right == null && node.Parent.Parent.Left == null)
            {
                RightLeftRotation(node);
            }
        }

        private void LeftRotation(Node node)
        {
            var middle = node;
            var top = node.Parent;

            if (top.Parent != null)
            {
                if (top.Parent.Right == top)
                {
                    top.Parent.Right = middle;
                }
                else
                {
                    top.Parent.Left = middle;
                }
            }
            else
            {
                this.Root = middle;
            }

            middle.Left = top;
            middle.Parent = top.Parent;

            top.Parent = middle;
            top.Right = null;
        }

        private void RightRotation(Node node)
        {
            var middle = node;
            var top = node.Parent;

            if (top.Parent != null)
            {
                if (top.Parent.Right == top)
                {
                    top.Parent.Right = middle;
                }
                else
                {
                    top.Parent.Left = middle;
                }
            }
            else
            {
                this.Root = middle;
            }

            middle.Right = top;
            middle.Parent = top.Parent;

            top.Parent = middle;
            top.Left = null;
        }

        private void LeftRightRotation(Node node)
        {
            LeftRotation(node);
            RightRotation(node);
        }

        private void RightLeftRotation(Node node)
        {
            RightRotation(node);
            LeftRotation(node);
        }
    }
}
