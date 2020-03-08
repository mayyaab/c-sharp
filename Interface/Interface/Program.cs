using System;

namespace Interface
{
    class Program
    {
        public interface INotifications
        {
            //Members
            void showNotification();
            string getDate();

        }


        public class Notification: INotifications
        {
            private string sender;
            private string message;
            private string date;

            //default constractor
            public Notification()
            {
                sender = "Admin";
                message = "hello";
                date = " ";
            }

            public Notification(string mySender, string myMessage, string myDate)
            {
                this.sender = mySender;
                this.message = myMessage;
                this.date = myDate;
            }

            public void showNotification()
            {
                Console.WriteLine("Message {0} - was sent by {1} - at {2}", message,sender,date);
            }

            public string getDate()
            {
                return date;
            }
        }

        static void Main(string[] args)
        {
            Notification n1 = new Notification("Denis", "hello world", "March 7");
            Notification n2 = new Notification("Frank", "hello", "today");

            n1.showNotification();
            n2.showNotification();
        }
    }
}
