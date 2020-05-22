using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;

namespace Game
{
    public class Commands : OrderedDictionary
    {
        public Command SingleCommand { get; }
        public Commands(Command singleCommand)
        {
            SingleCommand = singleCommand;
        }

        public Commands()
        {
        }

        public void Add(string name, string description, Action commandAction)
        {
            var command = new Command(name, description, commandAction);

            Add(name, command);
        }

        public void Add(string name, Action commandAction)
        {
            var command = new Command(name, commandAction);

            Add(name, command);
        }

        public void Run(int index, string name)
        {
            //var value = Values[index]
        }

        public void Run(int index)
        {
           Run(index, null);
        }

        public void Run(string name)
        {
            //foreach (var eCommand in Commands)
            //{

            //}
        }

        public Command GetCommand(int index)
        {
            //var element = ;
            //return element;
            return null;
        }

        public int GetSize()
        {
            return this.Count;
        }

        public void GetCommandList()
        {
            ICollection keyCOllection = Keys;
            ICollection valueCollection = Values;

            String[] myKeys = new String[Count];
            String[] myValuesName = new String[Count];

            keyCOllection.CopyTo(myKeys, 0);
            valueCollection.CopyTo(myValuesName, 0);

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("Key: " + myKeys[i]);
                Console.WriteLine("Value Name: " + myValuesName[i]);
            }
        }
    }
}
