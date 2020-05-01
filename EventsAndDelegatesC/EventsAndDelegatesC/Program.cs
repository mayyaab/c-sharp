using System.Security.Cryptography.X509Certificates;

namespace EventsAndDelegatesC
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new File() {Title = "File 1"};
            var downloadHelper = new DownloadHelper(); //publisher
            var unpackService = new UnpackService(); //receiver
            var notificationService = new NotificationService();
            downloadHelper.FileDownloaded += unpackService.OnFileDownloaded;
            downloadHelper.FileDownloaded += notificationService.OnFileDownloaded;

            downloadHelper.Download(file);
        }
    }
}
