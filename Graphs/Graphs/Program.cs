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
            new List<int>() {6},     // successors of vertice 3
            new List<int>() {0},     // successors of vertice 4
            new List<int>() {},      // successors of vertice 5
            new List<int>() {1, 2, 3}  // successors of vertice 6
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

        static bool IsWay(int x, int y)
        {
            if (x == y)
            {
                return true;
            }

            visited[x] = true;
            foreach (int child in graph.GetSuccessors(x))
            {
                if (!visited[child] && IsWay(child, y))
                {
                    return true;
                }
            }

            return false;
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

            Console.WriteLine(IsWay(1, 5));

        }
    }
}
