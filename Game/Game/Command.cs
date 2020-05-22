using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Command
    {
        public string Name { get; }
        public string Description { get; }
        public Action CommandAction { get; }

        public Command(string name, Action commandAction)
        {
            Name = name;
            CommandAction = commandAction;
        }

        public Command(string name, string description, Action commandAction)
        {
            Name = name;
            Description = description;
            CommandAction = commandAction;
        }
    }
}
