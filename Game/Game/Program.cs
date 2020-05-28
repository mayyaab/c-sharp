using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;
            var field = new Field();

            var commands = new CommandList();

            commands.Add("USAGE", "Prints the usage", () => { commands.PrintCommandList(); });
            commands.Add("START", "Print the field", () =>
            {
                Console.WriteLine("New game started");
                PrintField(field);
            });

            commands.Add("NEXT", "Add a temp", () =>
            {
                field.PlaceBalls();
                PrintField(field);
            });

            commands.Add("SWITCH", "Switch two balls", () =>
            {
                SwitchBalls(field);
            });

            commands.Add("END", "Finish the game", () =>
            {
                doLoop = false;
            });

            commands.PrintCommandList();


            while (doLoop)
            {
                string line = Console.ReadLine();

                try
                {
                     var result = Convert.ToInt32(line);
                     commands.Run(result);
                }
                catch
                {
                    commands.Run(line);
                }
            }
        }

        private static Position ParsePosition(string input)
        {
            string[] tokens = Regex.Split(input, @"\D+");
            try
            {
                int a = int.Parse(tokens[0]);
                int b = int.Parse(tokens[1]);

                var position = new Position(a, b);

                return position;
            }
            catch
            {
                return null;
            }
        }

        private static void PrintField(Field field)
        {
            const string format = "{0,8}";

            Console.Write(format, "");
            for (int i = 0; i < field.Width; i++)
            {
                Console.Write(format, i);
            }
            Console.WriteLine("\n");

            for (int row = 0; row < field.Height; row++)
            {
                Console.Write(format, row);
                for (int col = 0; col < field.Width; col++)
                {
                    Console.Write(format, field.GetBallColorAt(row, col));
                }
                Console.WriteLine();
            }
        }

        private static void SwitchBalls(Field field)
        {
            Console.WriteLine("Source [row column]: ");
            var source = ParsePosition(Console.ReadLine());

            if (source == null)
            {
                Console.WriteLine("Wrong format!");

            }

            Console.WriteLine("Destination [row column]: ");
            var destination = ParsePosition(Console.ReadLine());
            if (destination == null)
            {
                Console.WriteLine("Wrong format!");
            }

            field.MoveBall(source, destination);
        }
    }
}
