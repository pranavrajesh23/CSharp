using System;
using System.Threading;
namespace EventAndDelegates
{
    public class VideoEventArgs : EventArgs{
        public Video Video { get; set; }
    }
    class VideoEncoder{
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); //delegate
        public event VideoEncodedEventHandler VideoEncoded; //event
        public void Encode(Video video){
            Console.WriteLine("Encoding video: " + video.Title);
            Thread.Sleep(3000);
            Console.WriteLine("Encoding Completed!");
            OnVideoEncoded(video);
        }
        protected virtual void OnVideoEncoded(Video video) {   
            if(VideoEncoded!=null)
            {
                VideoEncoded(this, new VideoEventArgs()
                {
                    Video = video
                });
            }
        }
    }
    public class Video{
        public string Title { get; set; }
    }
    class Program{
        public static void Main(string[] args){
            Video video = new Video();
            video.Title = "Dance Video";
            VideoEncoder videoEncoder = new VideoEncoder();//publisher
            MailService mail = new MailService(); //subscriber
            TextService text = new TextService(); //subscriber
            videoEncoder.VideoEncoded += mail.OnVideoEncoded; //subscription
            videoEncoder.VideoEncoded += text.OnVideoEncoded; //subscription

            videoEncoder.Encode(video);
        }
    }
    public class MailService{
        public void OnVideoEncoded(object source,VideoEventArgs e){
            Console.WriteLine("MailService: Sending email.."+e.Video.Title); ;
        }
    }
    public class TextService{
        public void OnVideoEncoded(object source,VideoEventArgs e){
            Console.WriteLine("TextService: Sending text..."+e.Video.Title);
        }
    }
}