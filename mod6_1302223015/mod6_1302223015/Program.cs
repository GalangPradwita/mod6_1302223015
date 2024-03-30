namespace mod6_1302223015
{
    internal class Program
    {

        public class SayaTubeUser
        {
            private int id;
            private  List<SayaTubeVideo> uploadedVideos;
            public String username;

            public SayaTubeUser(String username)
            {
                 this.username = username;
                 this.uploadedVideos = new List<SayaTubeVideo> ();
                Random idRandom = new Random();// id random
                id = idRandom.Next(1000, 100000);

            }
            public int GetTotalVideoPlayCount()
            {   
                int total = 0;
                foreach (var video in uploadedVideos)
                {
                    total += video.GetPlayCount();
               
                }
                return total;
            }
            public void AddVideo(SayaTubeVideo video)
            {
                uploadedVideos.Add(video);
            }
            public void PrintAllVideoPlaycount()
            {
                Console.WriteLine("user =" + username);

                for (int i  = 0; i < uploadedVideos.Count; i++)
                {
                    Console.WriteLine("Video" + (i+1) + uploadedVideos[i].GetTitle());
                }
            }
        }

        public class SayaTubeVideo
        {
            private int id;
            private String title;
            private int playCount;
            public int GetPlayCount()
            {
                return playCount;
            }
            public String GetTitle()
            {
                return title;
            }

            //Konstruktor
            public SayaTubeVideo(String videoTitle)
            {
                if (videoTitle == null)
                {
                    throw new ArgumentNullException(nameof(videoTitle), "Judul Video Tidak Boleh Kosong");
                }
                else if (videoTitle.Length > 100)
                {
                    throw new ArgumentException(nameof(videoTitle), "Judul Video Tidak Boleh Lebih dari 100 Karakter");
                }

                Random idRandom = new Random();// id random
                id = idRandom.Next(1000, 100000);

                title = videoTitle;
                playCount = 0;

            }
            public void IncreasePlayCounting(int Count)
            {

                if (Count > 10000000)
                {
                    throw new ArgumentOutOfRangeException(nameof(Count), "Penambahan Play Count Telah Mencapai Jumlah Maksimum");
                }

                try
                {
                    checked
                    {
                        playCount += Count;
                    }
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Error: Penambahan Play Count Telah Mencapai Jumlah Maksimum.");
                }

            }

            public void PrintVideoDetails()
            {
                Console.WriteLine("ID: " + id + ", Judul: " + title + ", Play Count: " + playCount);
            }
        }

        static void Main(string[] args)
        {
            SayaTubeUser sayaTubeUser = new SayaTubeUser("Galang");
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test1"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test2"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test3"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test4"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test5"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test6"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test7"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test8"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test9"));
            sayaTubeUser.AddVideo(new SayaTubeVideo("Test10"));
            sayaTubeUser.PrintAllVideoPlaycount();

           
        }
    }
}
