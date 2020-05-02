using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Supported commands:");
            // TG: implement usage
            Console.WriteLine("1|usage: Prints the usage.");
            Console.WriteLine("3|show: Print the field");
            Console.WriteLine("4|next: Add a temp");
            Console.WriteLine("5|switch: Switch two balls");
            Console.WriteLine("6|finish: Finish ");

            bool doLoop = true;

            var newField = new Field();
            while (doLoop)
            {
                string line = Console.ReadLine();

                switch (line.ToUpper())
                {
                    case "SHOW":
                    case "3":
                    {
                        Console.WriteLine("New game started");
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
                        Console.WriteLine("Source [row column]: ");
                        var source = ParsePosition(Console.ReadLine());

                        if (source == null)
                        {
                            Console.WriteLine("Wrong format!");
                            break; //I need to call case 5
                        }

                        // TG: verify that is valid position

                        Console.WriteLine("Destination [row column]: ");
                        var destination = ParsePosition(Console.ReadLine());
                        if (destination == null)
                        {
                            Console.WriteLine("Wrong format!");
                            break; //I need to call case 5
                        }
                        // TG: verify that is valid position

                        newField.MoveBall(source, destination);
                        PrintField(newField);
                        break;
                    }

                    case "END":
                    case "6":
                    {
                        doLoop = false;
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("command is not supported");
                        break;
                    }
                }
            }
        }

        // TG: Implement the function. Input format: row,col
        // TG: Throw exception on error.
        // TG: Consider using regex to parse the input.
        private static Position ParsePosition(string input)
        {
            string[] tokens = input.Split();
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
    }
}
