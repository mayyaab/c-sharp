using System;
using System.Runtime.CompilerServices;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // get user input in a loop here
            // it should handle different commands
            // 1) "show" command should print the field
            // Some useful example https://www.dotnetperls.com/console-readline
            // 2) add a temp (it shouldn't be in a game) command "next" that will place
            //    next 3 balls on a field
            Field newField = new Field();
            while (true)
            {
                Console.WriteLine("Choose:");
                Console.WriteLine("show: Print the field");
                Console.WriteLine("next: Add a temp");
                Console.WriteLine("finish: Finish ");
                string line = Console.ReadLine();
                if (line == "show") // Try to parse the string as an integer
                {
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
