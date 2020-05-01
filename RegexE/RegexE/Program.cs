using System;
using System.Text.RegularExpressions;

namespace RegexE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string pattern = @"\d";
            Regex regex = new Regex(pattern);

            string text = " Hi my number is 12341324";

            MatchCollection matchCollection = regex.Matches(text);

            Console.WriteLine("{0} hits found:\n {1}", matchCollection, text);

            foreach (Match hit in matchCollection)
            {
                GroupCollection group = hit.Groups;
                Console.WriteLine("{0} found at {1}", group[0].Value, group[0].Index);
            }

        }
    }
}
