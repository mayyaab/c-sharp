using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // TG: add support for numeric commands as well
            Console.WriteLine("Supported commands:");
            // TG: implement usage
            Console.WriteLine("1|usage: Prints the usage.");
            Console.WriteLine("3|show: Print the field");
            Console.WriteLine("4|next: Add a temp");
            Console.WriteLine("5|finish: Finish ");


            var newField = new Field();
            while (true)
            {
                string line = Console.ReadLine();

                // TG: consider replacing with switch
                if (line == "show")
                {
                    // TG: that should be only once
                    Console.WriteLine("New game started");
                    newField.Print();
                }
                else if (line == "next")
                {
                    newField.PlaceBalls();
                }
                else if (line == "finish")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("NOT VALID");
                }

            }

        }
    }
}
