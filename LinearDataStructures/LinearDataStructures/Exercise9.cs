using System;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    class Exercise9
    {
       /*We are given the following sequence:

    S1 = N;

    S2 = S1 + 1;

    S3 = 2*S1 + 1;

    S4 = S1 + 2;

    S5 = S2 + 1;

    S6 = 2*S2 + 1;

    S7 = S2 + 2;

    …

    Using the Queue<T> class, write a program which by given N prints on the console the first 50 elements of the sequence.

*/
        public static void Ex9()
        {
            Queue<int> queueEx9 = new Queue<int>();


            int N = 2;
            queueEx9.Enqueue(N);

            for (int i = 0; i < 50; i++)
            {
                int M = queueEx9.Peek();
                queueEx9.Enqueue(M + 1);
                queueEx9.Enqueue(2 * M + 1);
                queueEx9.Enqueue(M + 2);

                foreach (int queueElement in queueEx9)
                {
                    Console.WriteLine(queueElement);
                }

                for (int m = 0; m < 3; m++)
                {
                    queueEx9.Dequeue();
                }
               
            }
        }
    }
}
