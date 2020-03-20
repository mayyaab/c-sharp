using System;

namespace Struct
{
    class Program
    {
        struct Game
        {
            public string name;
            public string developer;
            public double rating;
            public string releaseDate;

            public void Displayed()
            {
                Console.WriteLine("Game 1's name is :{0}", name);
                Console.WriteLine("Game 1's developer is :{0}", developer);
                Console.WriteLine("Game 1's rating is :{0}", rating);
                Console.WriteLine("Game 1's release date is :{0}", releaseDate);
            }

            public Game(string name, string developer, double rating, string releaseDate)
            {
                this.name = name;
                this.developer = developer;
                this.rating = rating;
                this.releaseDate = releaseDate;
            }
        }
        static void Main(string[] args)
        {
            Game game1;

            game1.name = "Pokemon go";
            game1.developer = "Niantic";
            game1.rating = 3.5;
            game1.releaseDate = "03.19.20";

            game1.Displayed();

            Console.ReadKey();
        }
    }
}
