using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post("Thank for the b-day wishes", true, "Maya A");
            Console.WriteLine(post1.ToString());
            Console.ReadLine();

            ImagePost imagePost1 = new ImagePost("Check out my new shoes", "Mayya", "https://image.com", true);

            Console.WriteLine(imagePost1.ToString());
            Console.ReadLine();
        }
    }
}
