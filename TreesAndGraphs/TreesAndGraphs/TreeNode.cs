using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class TreeNode<T>
    {
        private T value;

        private bool hasPerent;

        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Can not insert null value");
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentException("Can not insert null value");
            }

            if (child.hasPerent)
            {
                throw new ArgumentException("Node already has a parent");
            }

            child.hasPerent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
}
