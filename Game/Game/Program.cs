using System;
using System.Linq.Expressions;

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
                        newField.PlaceBalls();
                        PrintField(newField);
                        break;
                    }

                    case "SWITCH":
                    case "5":
                    {
                        Console.WriteLine("Source Row: ");
                        var sourceRow = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Source Column: ");
                        var sourceColumn = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Destination Row: ");
                        var destinationRow = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Source Column: ");
                        var destinationColumn = Convert.ToInt32(Console.ReadLine());

                        var source = new Position(sourceRow, sourceColumn);
                        var destination = new Position(destinationRow, destinationColumn);

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



        public static void PrintField(Field field)
        {
            for (int row = 0; row < field.Height; row++)
            {
                for (int col = 0; col < field.Width; col++)
                {
                    var forPrint = field.GetColor(new Position(row, col));
                    Console.Write("{0,8}", forPrint);
                }
                Console.WriteLine();
            }
        }

    }
}
