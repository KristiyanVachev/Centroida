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

            //if (newNode.Value == 8)
            //{
            //    NeedsBalance(newNode);
            //}
        }

        private bool NeedsBalance(Node node)
        {
            //Node grandGrandParent = null;
            //Node grandparent = null;
            //Node parent = null;
            //Node child = this.Root;

            //while (child != node)
            //{
            //    grandGrandParent = grandparent;
            //    grandparent = parent;
            //    parent = child;

            //    if (node.Value < child.Value)
            //    {
            //        child = child.Left;
            //    }
            //    else
            //    {
            //        child = child.Right;
            //    }

            //}

            if (node.Parent == null || node.Parent.Parent == null)
            {
                return false;
            }

            if (node.Parent.Left == null || node.Parent.Right == null && node.Parent.Parent.Left == null || node.Parent.Parent.Right == null)
            {
                this.Rotate(node);
                return true;
            }

            return false;
        }

        private void Rotate(Node node)
        {
            if (node.Parent.Left == null && node.Parent.Parent.Left == null)
            {
                LeftRotation(node);
            }
        }

        private void LeftRotation(Node node)
        {
            var grandGrandParent = node.Parent.Parent.Parent;

            if (grandGrandParent == null)
            {
                this.Root = node.Parent;
                this.Root.Parent = null;

                //this.Root.Left = node.Parent.Parent;
                //node.Parent.Parent.Parent = this.Root;
            }
            else
            {
                var newSibling = grandGrandParent.Right;
                grandGrandParent.Right = node.Parent;

                node.Parent.Left = newSibling;
                //newSibling.Parent = 
            }

        }
    }
}
