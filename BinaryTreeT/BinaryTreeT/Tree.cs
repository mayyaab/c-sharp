using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeT
{
    public class Tree
    {
        public BinaryTree<int> _root;
       
        
        //Write a program that finds in a binary tree of numbers the sum of the vertices of each level of the tree.
        public static List<int> VerticesSumByLevel(BinaryTree<int> root, List<int> list = null, int level = 0)
        {
            if (list == null)
            {
                list = new List<int>();
            }

            if (level == list.Count)
            {
                list.Add(root.Value);
            }

            else
            {
                list[level] += root.Value;
            }

            if (root.LeftChild != null)
            {
                VerticesSumByLevel(root.LeftChild, list, level + 1);
            }
            

            if (root.RightChild != null)
            {
                VerticesSumByLevel(root.RightChild, list, level + 1);
            }
            return list;
        }
        
    }
}
