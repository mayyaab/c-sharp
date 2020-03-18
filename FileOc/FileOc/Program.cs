using System;
using System.IO;
using System.Threading.Channels;

namespace FileOc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1 - reading Text
            /*string text =
                System.IO.File.ReadAllText(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\textFile.txt");

            Console.WriteLine("Text file contains following text: {0}", text);

            //Example 2 - reading Text
            string[] lines =
                System.IO.File.ReadAllLines(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\textFile.txt");

            Console.WriteLine("Text file contains following text by lines: ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }

            Console.ReadKey();*/


            //Example 1 - writing Text
            string[] linesWrite = {"250", "242", "Third 240"};

            /*File.WriteAllLines(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\textFile2.txt", linesWrite);

            //Example 2 - writing Text
            Console.WriteLine("File name: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Text: ");
            string input = Console.ReadLine();
            File.WriteAllText(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\" + fileName + ".txt", input);*/

            //Example 3 - writing Text

            using (StreamWriter file = new StreamWriter(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\myText.txt"))
            {
                foreach (string line in linesWrite)
                {
                    if (line.Contains("Third"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamWriter file =
                new StreamWriter(@"C:\Users\m.abzhigitova\source\repos\c-sharp\FileOc\myText.txt", true))
            {
                file.WriteLine("Additional line");
            }
        }
    }
}
