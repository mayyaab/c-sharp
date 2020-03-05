using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Inheritance
{
    class VideoPost:Post
    {
        //member fields
        protected bool isPlaying = false;
        protected int currDuration = 0;
        private Timer timer;


        //Properies
        protected string videoURL { get; set; }
        protected int length { get; set; }


        public VideoPost() { }

        public VideoPost(string title, string sendByUsername, string videoUrl, int length, bool isPublic)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.videoURL = videoUrl;
            this.length = length;
            this.IsPublic = isPublic;
        }

        public void Play()
        {
            if (!isPlaying)
            {
                Console.WriteLine("Playing");
                timer = new Timer(TimerCallback, null, 0, 1000);
            }
            
        }

        private void TimerCallback(Object o)
        {
            if (currDuration < length)
            {
                currDuration++;
                Console.WriteLine("Video at {0}s", currDuration);
                GC.Collect();
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            if (isPlaying)
            {
                Console.WriteLine("Stopped at {0}", currDuration);
                currDuration = 0;
                timer.Dispose();
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - Length: {3} by {4}", this.ID, this.Title, this.videoURL, this.length, this.SendByUsername);
        }

    }
}
