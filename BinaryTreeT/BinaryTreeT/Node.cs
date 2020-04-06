using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeT
{
    public class BinaryTree<T>

    {
        public T Value { get; set; }
        public BinaryTree<T> LeftChild { get;  set; }
        public BinaryTree<T> RightChild { get;  set; }

        public BinaryTree(T value,
            BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinaryTree(T value) : this(value, null, null)
        {

        }

        //Traverses the binary tree in pre-order
        public void PrintInOrder()
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintInOrder();
            }
            Console.Write(this.Value + " ");
            if (this.RightChild != null)
            {
                this.RightChild.PrintInOrder();
            }
        }

        //DFS
        public void PrintDFS()
        {
            Console.Write(this.Value + " ");

            if (this.LeftChild != null)
            {
                this.LeftChild.PrintDFS();
            }

            if (this.RightChild != null)
            {
                this.RightChild.PrintDFS();
            }
        }


        //Write a program that finds and prints all vertices of a binary tree, which have for only leaves successors.

        public void PrintVertices()
        {
            if (this.LeftChild != null || this.RightChild != null)
            {
                Console.WriteLine(this.Value);
            }
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintVertices();
            }

            if (this.RightChild != null)
            {
                this.RightChild.PrintVertices();
            }
        }

    }
}
