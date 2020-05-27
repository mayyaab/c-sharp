﻿using System;

namespace Game
{
    public class Command
    {
        public string Name { get; }
        public string Description { get; }
        public Action Action { get; }

        public Command(string name, Action action)
        {
            Name = name;
            Action = action;
        }

        public Command(string name, string description, Action action)
        {
            Name = name;
            Description = description;
            Action = action;
        }
    }
}
