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

            VideoPost videoPost1 = new VideoPost("Watch the video", "Mayya", "https://video.com", 4, true);
            Console.WriteLine(videoPost1.ToString());
            videoPost1.Play();
            Console.WriteLine("Press any key to stop the video");
            Console.ReadKey();
            videoPost1.Stop();
            Console.ReadLine();
        }
    }
}
