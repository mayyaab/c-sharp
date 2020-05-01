using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAndDelegatesC
{
    public class NotificationService
    {
        public void OnFileDownloaded(object source, FileEventArgs e)
        {
            Console.WriteLine("Notifying user that downloaded is done " + e.File.Title);
        }
    }
}
