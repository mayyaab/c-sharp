using System;
using System.Text.RegularExpressions;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;

            PrintUsage();
            var newField = new Field();
            while (doLoop)
            {
                string line = Console.ReadLine();
                switch (line.ToUpper())
                {
                    case "USAGE":
                    case "1":
                    {
                        PrintUsage();
                        break;
                    }

                    case "START":
                    case "2":
                    {
                        Console.WriteLine("New game started");
                        //newField.PlaceBalls2();
                        PrintField(newField);
                        break;
                    }

                    case "NEXT":
                    case "4":
                    {
                        newField.PlaceBalls2();
                        PrintField(newField);
                        break;
                    }

                    case "SWITCH":
                    case "5":
                    {
                        SwitchBalls(newField);
                        break;
                    }

                    case "END":
                    case "6":
                    {
                        doLoop = false;
                        break;
                    }

                    case "7":
                    {
                        Console.WriteLine("position [row column]: ");
                        var position = ParsePosition(Console.ReadLine());

                        if (position == null)
                        {
                            Console.WriteLine("Wrong format!");
                        }

                        var result = newField.GetLineHorizontal(position, 2);
                        if (result == null)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            foreach (var i in result)
                            {
                                Console.WriteLine("position row {0}, col {1}", i.Row, i.Column);
                            }
                        }
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("command is not supported");
                        break;
                    }
                }

                //while (line != "6")
                //{
                //    SwitchBalls(newField);
                //    newField.PlaceBalls2();
                //    PrintField(newField);
                //}
            }
        }

        // TG: Implement the function. Input format: row,col
        // TG: Throw exception on error.
        // TG: Consider using regex to parse the input.
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

            // TG: verify that is valid position

            Console.WriteLine("Destination [row column]: ");
            var destination = ParsePosition(Console.ReadLine());
            if (destination == null)
            {
                Console.WriteLine("Wrong format!");
            }
            // TG: verify that is valid position

            field.MoveBall(source, destination);
        }
    }
}
