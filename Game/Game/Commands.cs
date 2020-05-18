using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Text;

namespace Game
{
    public class Commands: OrderedDictionary
    {

        public void Add(string name,  Action description)
        {
            Add(name, description);
        }

        public void Add(string name)
        {
            Add(name, null);
        }

        public void Run(int index, string name)
        {
            if (Contains(index) || Contains(name))
            {
                Action func = (Action) this[name];
                func();
            }
        }

        public void Run(int index)
        {
           Run(index, null);
        }

        public void Run(string name)
        {
            Run(0, name);
        }

        public void DisplayContents()
        {
            String[] myKeys = new String[Count];
            String[] myValues = new String[Count];
            CopyTo(myKeys, 0);
            CopyTo(myValues, 0);

            // Displays the contents of the OrderedDictionary
            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("   {0,-5} {1,-25} {2}",
                    i, myKeys[i], myValues[i]);
            }
            Console.WriteLine();
        }
    }
}
