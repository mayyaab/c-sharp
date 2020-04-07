using System;

namespace BinaryTreeT
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree =
            new BinaryTree<int>(14,
                    new BinaryTree<int>(19,
                          new BinaryTree<int>(23),
                          new BinaryTree<int>(6,
                                  new BinaryTree<int>(10),
                                  new BinaryTree<int>(21))),
                    new BinaryTree<int>(15,
                          new BinaryTree<int>(3),
                          new BinaryTree<int>(3)));
            binaryTree.PrintInOrder();
            Console.WriteLine("-----");
            //binaryTree.PrintDFS();

            Console.WriteLine("Write a program that finds in a binary tree of numbers the sum of the vertices of each level of the tree.");
            var list = Tree.VerticesSumByLevel(binaryTree, null, 0);
            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Write a program that finds and prints all vertices of a binary tree, which have for only leaves successors.");
            binaryTree.PrintVertices();

            Console.WriteLine("Write a program that checks whether a binary tree is perfectly balanced.");
            Console.WriteLine(binaryTree.IsBalanced());
        }
    }
}
