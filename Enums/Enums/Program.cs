using System;

namespace Enums
{
    class Program
    {
        enum Day
        {
            Mo,
            Tu,
            We,
            Th,
            Fr,
            Sa,
            Su
        };

        enum Month
        {
            Jan = 1,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul = 12,
            Aug,
            Sep,
            Oct,
            Dec
        };

        static void Main(string[] args)
        {
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;

            Console.WriteLine(fr == a);
            Console.WriteLine(Day.Mo);
            Console.WriteLine((int)Day.Mo);

            Console.WriteLine(Month.Feb);
            Console.WriteLine((int)Month.Feb);

            Console.WriteLine(Month.Aug);
            Console.WriteLine((int)Month.Aug);
            Console.ReadKey();
        }
    }
}
