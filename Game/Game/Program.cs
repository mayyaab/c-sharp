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
            CommandList newCommandList = new CommandList();
            newCommandList.Add("name1", "desc1", () => { });
            newCommandList.Add("name2", "desc2", () => { });
            newCommandList.PrintCommandList();
            var command = newCommandList.GetCommand(0);
            Console.WriteLine(command.Name);
            Console.WriteLine(command.Description);


            bool doLoop = true;
            var newField = new Field();

            Dictionary<string, Action> commands = new Dictionary<string, Action>();
            commands.Add("USAGE", PrintUsage);
            commands.Add("START", () =>
            {
                Console.WriteLine("New game started");
                PrintField(newField);
            });

            commands.Add("NEXT", () =>
            {
                newField.PlaceBalls();
                PrintField(newField);
            });

            commands.Add("SWITCH", () =>
            {
                SwitchBalls(newField);
            });

            commands.Add("END", () =>
            {
                doLoop = false;
            });

            PrintUsage();
            while (doLoop)
            {
                string line = Console.ReadLine();

                if (commands.ContainsKey(line))
                {
                    var func = commands[line];
                    func();
                }
                else
                {
                    Console.WriteLine("Command is not supported");
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

        private static void PrintUsage()
        {
            Console.WriteLine("Supported commands:");
            Console.WriteLine("1|usage: Prints the usage.");
            Console.WriteLine("2|start: Print the field");
            Console.WriteLine("4|next: Add a temp");
            Console.WriteLine("5|switch: Switch two balls");
            Console.WriteLine("6|finish: Finish ");
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
