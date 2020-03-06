using System;
using System.Threading;

namespace Exerciceami
{
   

    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;



        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video..");
            Thread.sleep(3000);

            onVideoEncoded();
        }
    }

    protected virtual void onVideoEncoded()
    {
        if (VideoEncoded != null)
            VideoEncoded(this, EventArgs.Empty);
    }




    class Program
    {
        static void  Main(string[] args)
        {

            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();

            videoEncoder.VideoEncoded += mailService.onVideoEncoded;

            videoEncoder.Encode(video);

        }
    }

    public class MailService
    {
        public void VideoEncodedEventHandler(object source, EventArgs e)
        {
            Console.WriteLine("mailService: entrer votre email...");
        }
    }
}
