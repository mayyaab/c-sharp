using System;
using System.Collections.Specialized;

namespace Game
{
    // TG: replace with the composition
    public class CommandList : OrderedDictionary
    {
        public Command Command { get; }

        public CommandList(Command command)
        {
            Command = command;
        }

        public CommandList()
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
            if (index != null)
            {
                Run(index);
            }

            if (name != null)
            {
                Run(name);
            }

            else
            {
                Console.WriteLine("Command is not supported");
            }
        }

        public void Run(int index)
        {
            var element = (Command)this[index];
            var action = element.Action;
            action();
        }

        public void Run(string name)
        {
            var lowerCaseName = name.ToLowerInvariant();

            if (Contains(lowerCaseName))
            {
                var func = (Command)this[lowerCaseName];
                var action = func.Action;
                action();
            }
        }

        public Command GetCommand(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index can not be negative");
            }

            var element = (Command)this[index];
            return element;
        }

        // TG: change to property
        public int GetSize()
        {
            return this.Count;
        }

        public void PrintCommandList()
        {
            var valueCollection = Values;
            var i = 1;

            foreach (var val in valueCollection)
            {
                var getValue = (Command)val;
                Console.WriteLine("{0}|{1}: {2}", i, getValue.Name, getValue.Description);
                i++;
            }
        }
    }
}
