using System;

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

            Balance(newNode);
        }

        public bool Find(int value)
        {
            var currentNode = this.Root;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }

                if (value > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            return false;
        }

        private void Balance(Node newNode)
        {
            var currentNode = newNode.Parent;

            while (currentNode != null)
            {
                int leftDepth = GetDepth(currentNode.Left);
                int rightDepth = GetDepth(currentNode.Right);

                if (Math.Abs(leftDepth - rightDepth) > 1)
                {
                    if (rightDepth > leftDepth)
                    {
                        //left or left-right
                        if (GetDepth(currentNode.Right.Right) > GetDepth(currentNode.Right.Left))
                        {
                            LeftRotation(currentNode.Right);
                        }
                        else
                        {
                            LeftRightRotation(currentNode.Right.Right);
                        }
                    }
                    else
                    {
                        if (GetDepth(currentNode.Left.Left) > GetDepth(currentNode.Left.Right))
                        {
                            RightRotation(currentNode.Left);   
                        }
                        else
                        {
                            RightLeftRotation(currentNode.Left.Left);
                        }
                    }
                    return;
                }

                currentNode = currentNode.Parent;
            }
        }

        private int GetDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftDepth = 0;
            int rightDepth = 0;

            if (node.Left != null)
            {
                leftDepth = GetDepth(node.Left);
            }

            if (node.Right != null)
            {
                rightDepth = GetDepth(node.Right);
            }

            return 1 + Math.Max(leftDepth, rightDepth);
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

            top.Right = middle.Left;

            middle.Left = top;
            middle.Parent = top.Parent;

            top.Parent = middle;
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

            top.Left = middle.Right;

            middle.Right = top;
            middle.Parent = top.Parent;

            top.Parent = middle;
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
