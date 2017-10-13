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

        public void Print()
        {
            this.Root.PrintPretty("", false);
        }

        public bool Exists(int value)
        {
            return this.Find(value) != null;
        }

        public void Remove(int value)
        {
            var nodeToRemove = this.Find(value);

            if (nodeToRemove == null)
            {
                return;
            }

            var nodeToRemoveParent = nodeToRemove.Parent;

            //If nodeToRemove has no children, just delete it
            if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Parent.Left == nodeToRemove)
                {
                    nodeToRemove.Parent.Left = null;
                }
                else
                {
                    nodeToRemove.Parent.Right = null;
                }
            }
            //IF nodeToRemove has only left child, place the child in its possition
            else if (nodeToRemove.Right == null)
            {
                if (nodeToRemove.Parent.Left == nodeToRemove)
                {
                    nodeToRemove.Parent.Left = nodeToRemove.Left;
                }
                else
                {
                    nodeToRemove.Parent.Right = nodeToRemove.Left;
                }
            }
            //If nodeToRemove has only right child, place the child in its possition
            else if (nodeToRemove.Left == null)
            {
                if (nodeToRemove.Parent.Left == nodeToRemove)
                {
                    nodeToRemove.Parent.Left = nodeToRemove.Right;
                }
                else
                {
                    nodeToRemove.Parent.Right = nodeToRemove.Right;
                }
            }
            else
            {
                //Find the smallest element after nodeToRemove
                var smallestRightChild = nodeToRemove.Right;

                while (smallestRightChild.Left != null)
                {
                    //leftMostParent = leftMost;
                    smallestRightChild = smallestRightChild.Left;
                }

                //Set leftmost's parent to have the leftmost's child
                if (smallestRightChild != nodeToRemove.Right)
                {
                    smallestRightChild.Parent.Left = smallestRightChild.Right;

                    smallestRightChild.Right = nodeToRemove.Right;

                    if (smallestRightChild.Right != null)
                    {
                        smallestRightChild.Right.Parent = smallestRightChild;
                    }

                    nodeToRemove.Right.Parent = smallestRightChild;
                }

                //Put in in the place of the node to be removed
                smallestRightChild.Left = nodeToRemove.Left;

                if (smallestRightChild.Left != null)
                {
                    smallestRightChild.Left.Parent = smallestRightChild;
                }

                nodeToRemove.Left.Parent = smallestRightChild;
                smallestRightChild.Parent = nodeToRemove.Parent;

                //Place leftMost in it's new parent's care
                if (nodeToRemove.Parent == null)
                {
                    this.Root = smallestRightChild;
                }
                else
                {
                    if (nodeToRemove.Parent.Left == nodeToRemove)
                    {
                        nodeToRemove.Parent.Left = smallestRightChild;
                    }
                    else
                    {
                        nodeToRemove.Parent.Right = smallestRightChild;
                    }
                }
            }

            Balance(nodeToRemoveParent);
        }

        private Node Find(int value)
        {
            var currentNode = this.Root;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
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

            return null;
        }

        private void Balance(Node node)
        {
            var currentNode = node;

            while (currentNode != null)
            {
                int leftDepth = GetDepth(currentNode.Left);
                int rightDepth = GetDepth(currentNode.Right);

                if (Math.Abs(leftDepth - rightDepth) > 1)
                {
                    if (rightDepth > leftDepth)
                    {
                        //left or left-right
                        if (GetDepth(currentNode.Right.Right) >= GetDepth(currentNode.Right.Left))
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
                        if (GetDepth(currentNode.Left.Left) >= GetDepth(currentNode.Left.Right))
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

            if (middle.Left != null)
            {
                middle.Left.Parent = top;
            }

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

            if (middle.Right != null)
            {
                middle.Right.Parent = top;
            }

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
