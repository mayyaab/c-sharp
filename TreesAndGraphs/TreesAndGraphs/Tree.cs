using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace TreesAndGraphs
{
    class Tree<T>
    {
        private TreeNode<T> _root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can not insert null value");
            }

            this._root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this._root.AddChild(child._root);
            }
        }

        public TreeNode<T> Root { get; }

        public void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this._root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + " ");
            }

        }

        public void TraverseDFS()
        {
            this.PrintDFS(this._root, string.Empty);
        }

        //1. Write a program that finds the number of occurrences of a number in a tree of numbers.
        public int GetAllChildrenCount(TreeNode<T> root)
        {
            if (root.ChildrenCount == 0)
            {
                return 0;
            }

            int count = 0;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                count += 1 + GetAllChildrenCount(root.GetChild(i));
            }

            return count;
        }

        public int GetAllChildrenCount()
        {
            return GetAllChildrenCount(this._root);
        }

        //2.    Write a program that displays the roots of those sub-trees of a tree, which have exactly k nodes, where k is an integer.
        public int PrintRootsWithKNodes(TreeNode<T> root, int k)
        {
            if (this._root == null)
            {
                return 0;
            }
             
            var allChildrenCount = 1;
            
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                allChildrenCount += PrintRootsWithKNodes(root.GetChild(i), k);
            }

            if (allChildrenCount == k)
            {
                Console.WriteLine(root.Value);
            }

            return allChildrenCount;
        }


        public void PrintRootsWithKNodes(int k)
        {
            PrintRootsWithKNodes(this._root, k);
        }

        //3. Write a program that finds the number of leaves and number of internal vertices of a tree.

        public Tuple<int, int> PrintLeaveasAndVerticesNumber(TreeNode<T> root)
        {
            if (this._root == null)
            {
                return new Tuple<int, int>(0, 0);
            }
            
            int internalVertices = 0;
            int leaves = 0;

            if (root.ChildrenCount == 0)
            {
                leaves++;
            }

            else if (root.ChildrenCount != 0)
            {
                internalVertices++;
            }

            for (int i = 0; i < root.ChildrenCount; i++)
            { 
                var result = PrintLeaveasAndVerticesNumber(root.GetChild(i));
                internalVertices += result.Item1;
                leaves += result.Item2;
            }

            return new Tuple<int, int>(internalVertices, leaves);
        }

        public Tuple<int, int> PrintLeaveasAndVerticesNumber()
        {
            return PrintLeaveasAndVerticesNumber(this._root);
        }
    }
}
