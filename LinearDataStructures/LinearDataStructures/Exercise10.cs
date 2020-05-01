using System;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    class Exercise10
    {
        /* We are given N and M and the following operations:

    N = N+1

    N = N+2

    N = N*2

    Write a program, which finds the shortest subsequence from the operations, which starts with N and ends with M. Use queue.

    Example: N = 5, M = 16*/

        public static void Ex10()
        {
            int n = 5;
            int m = 16;

            Queue<int> queueEx10 = new Queue<int>();

            do
            {
                queueEx10.Enqueue(n);
                queueEx10.Enqueue(n * 2);
                queueEx10.Enqueue(n + 2);
                queueEx10.Enqueue(n + 1);

            }
            while (queueEx10.Contains(m));

        }
    }
}
