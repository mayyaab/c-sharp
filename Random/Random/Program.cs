using System;

namespace Random
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Random dice = new System.Random();
            int numEyes;

            for (int i = 0; i < 10; i++)
            {
                numEyes = dice.Next(1, 7);
                Console.WriteLine(numEyes);
            }

            Console.WriteLine("-------");
            System.Random game = new System.Random();
            int yesMaybeNo;
            
            yesMaybeNo = game.Next(1, 4);
                Console.WriteLine(yesMaybeNo);
                if (yesMaybeNo == 1)
                {
                    Console.WriteLine("YES");
                }
                if (yesMaybeNo == 2)
                {
                    Console.WriteLine("MAY BE");
                }
                if (yesMaybeNo == 3)
                {
                    Console.WriteLine("NO");
                
            }

            Console.ReadKey();
        }
    }
}
