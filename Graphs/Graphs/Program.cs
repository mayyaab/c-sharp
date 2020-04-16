using System;
using System.Collections.Generic;

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

        static int IsWay(int x, int y)
        {
            if (x == y)
            {
                return 0;
            }
            visited[x] = true;

            foreach (int child in graph.GetSuccessors(x))
            {
                if (!visited[child])
                {
                    var result = IsWay(child, y);
                    if (result != -1)
                    {
                        return result + 1;
                    }
                }
            }
            return -1;
        }

        //  1 > 2 > 3 > 7
        //  IsWay(1, 7)

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

              Console.WriteLine(IsWay(1, 0));

        }
    }
}
