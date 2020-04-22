using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Graphs
{
    class GraphComponents
    {
        static Graph graph = new Graph(new List<int>[] {
            new List<int>() {4},     // successors of vertice 0
            new List<int>() {1, 2, 6}, // successors of vertice 1
            new List<int>() {1, 6},    // successors of vertice 2
            new List<int>() {6, 7},     // successors of vertice 3
            new List<int>() {0},     // successors of vertice 4
            new List<int>() {},      // successors of vertice 5
            new List<int>() {1, 2, 3},  // successors of vertice 6
            new List<int>() {3}, // successors of vertice 7
            new List<int>() {7, 1}  // successors of vertice 8

        });

        static bool[] visited = new bool[graph.Size];

        static void TraverseDFS(int v)
        {
            if (!visited[v])
            {
                Console.Write(v + " ");
                visited[v] = true;
                foreach (int child in graph.GetSuccessors(v))
                {
                    TraverseDFS(child);
                }
            }
        }

        static List<int> IsWay(int x, int y)
        {
            if (x == y)
            {
                return new List<int> { x };
            }
            visited[x] = true;
            List<int> minList = new List<int>();
            foreach (int child in graph.GetSuccessors(x))
            {
                if (!visited[child])
                {
                    var result = IsWay(child, y);
                    if (result.Count != 0)
                    {
                        if (minList.Count == 0 || result.Count < minList.Count)
                        {
                            minList = result;
                            minList.Add(x);
                        }
                    }
                }
            }
            return minList;
        }


        static void Main()
        {
            //Console.WriteLine("Connected graph components: ");
            //for (int v = 0; v < graph.Size; v++)
            //{
            //    if (!visited[v])
            //    {
            //        TraverseDFS(v);
            //        Console.WriteLine();
            //    }
            //}

            foreach (var element in IsWay(1, 0))
            {
                Console.WriteLine(element);
            }

        }
    }
}
