using System;
using System.Linq.Expressions;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // DONE TG: add support for numeric commands as well
            Console.WriteLine("Supported commands:");
            // TG: implement usage
            Console.WriteLine("1|usage: Prints the usage.");
            Console.WriteLine("3|show: Print the field");
            Console.WriteLine("4|next: Add a temp");
            Console.WriteLine("5|finish: Finish ");

            bool doLoop = true;

            var newField = new Field();
            while (doLoop)
            {
                string line = Console.ReadLine();
                // TG: consider replacing with switch

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
                        newField.MoveBall((2,2) , (3,3));

                        PrintField(newField);
                        break;
                    }

                    case "END":
                    case "5":
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
                    // field.GetColor(new Position(_row, col))
                    //Console.Write("{0,4}", _array[_row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
