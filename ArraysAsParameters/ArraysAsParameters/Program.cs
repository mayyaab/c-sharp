using System;

namespace ArraysAsParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] studentsGrade = new int[] { 13, 15, 14, 15, 19 };
            double averageReult = GetAverage(studentsGrade);

            foreach (int grade in studentsGrade)
            {
                Console.WriteLine(" {0} ", grade);
            }

            Console.WriteLine("The average grade: {0} ", averageReult);
            Console.ReadKey();
        }

        static double GetAverage(int[] gradesArray)
        {
            int size = gradesArray.Length;
            double average;
            int sum = 0;

            for (int i= 0; i < size; i++)
            {
                sum += gradesArray[i];
            }
            average = (double)sum / size;
            return average;
        }
    }
}
