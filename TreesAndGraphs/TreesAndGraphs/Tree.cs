using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace TreesAndGraphs
{
    class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can not insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root { get; }

        public void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
               return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for ( int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + " ");
            }

        }

        public void TraverseDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }

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



    }
}
