﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
