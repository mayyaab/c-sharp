using System;

namespace JaggedArraysChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] friendsArrays = new string[][]
            {
                new string[]{"Ilya", "Marina", "Vlad"},
                new string[]{"Bob", "Martine", "Kevin"},
            };
            
            for (int i = 0; i < friendsArrays.Length; i++)
            {
                Console.WriteLine("This is {0} family", i);
                for (int j = 0; j< friendsArrays[i].Length; j++)
                {
                    Console.WriteLine("Family members: {0} ", friendsArrays[i][j]);
                }
            }

        }
    }
}
