using System.Collections.Generic;
using System.IO;

namespace Algorithms_CSharp_Course
{
    class In
    {
        public static IEnumerable<int> ReadInts(string filePath)
        //IEnumerable - интерфйес
        {
            using (TextReader reader = File.OpenText(filePath))
            {
                string lastLine;
                while ((lastLine = reader.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }
        }

    }
}
