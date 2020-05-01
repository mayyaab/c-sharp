using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndDelegatesC
{
    public class FileEventArgs: EventArgs
    {
        public File File { get; set; }
    }
}
