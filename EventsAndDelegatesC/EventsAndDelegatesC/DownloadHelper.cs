using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace EventsAndDelegatesC
{
    public class DownloadHelper
    {
        //Step1 - create a delegate
        //public delegate void FileDownloadedEventHandler(object source, FileEventArgs args);

        //Step2 - create an event based on that delegate
        public event EventHandler<FileEventArgs> FileDownloaded;
        //Step3 - raised the event
        protected virtual void OnFileDownloaded(File file)
        {
            if (FileDownloaded != null)
            {
                FileDownloaded(this, new FileEventArgs(){File = file });
            }
        }

        public void Download(File file)
        {
            Console.WriteLine("Download file...");
            Thread.Sleep(4000);

            //Step3.1
            OnFileDownloaded(file);
        }

    }
}
