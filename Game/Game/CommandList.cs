using System;
using System.Collections;
using System.Collections.Specialized;

namespace Game
{
    public class CommandList
    {
        public Command Command { get; }

        private readonly OrderedDictionary _dictionary = new OrderedDictionary(StringComparer.InvariantCultureIgnoreCase);

        public CommandList()
        {
        }

        public void Add(string name, string description, Action commandAction)
        {
            var command = new Command(name, description, commandAction);

            _dictionary.Add(name, command);
        }

        public void Add(string name, Action commandAction)
        {
            var command = new Command(name, commandAction);

            _dictionary.Add(name, command);
        }


        public void Run(int index)
        {
            var element = (Command)_dictionary[index];
            var action = element.CommandAction;
            action();
        }

        public void Run(string name)
        {
            if (_dictionary.Contains(name))
            {
                var func = (Command)_dictionary[name];
                var action = func.CommandAction;
                action();
            }
        }

        public Command GetCommand(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index can not be negative");
            }

            var element = (Command)_dictionary[index];
            return element;
        }

        public int GetSize()
        {
            return _dictionary.Count;
        }

        public void PrintCommandList()
        {
            var valueCollection = _dictionary.Values;
            var i = 1;

            foreach (var val in valueCollection)
            {
                var getValue = (Command)val;
                Console.WriteLine("{0}|{1}: {2}", i, getValue.Name, getValue.Description);
                i++;
            }

            for (int index =0; index < _dictionary.Count; ++index)
            {
                DictionaryEntry entry = (DictionaryEntry)_dictionary[index];
                // index ,  entry.value.Name .. Descrtion
            }
        }
    }
}
