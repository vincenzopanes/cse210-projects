using System;
using System.Collections.Generic;


public class Program
{
   static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Programming Hub", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing."));
        videos.Add(video1);

        Video video2 = new Video("Top 10 Soccer Goals", "Sports Channel", 420);
        video2.AddComment(new Comment("David", "Amazing goals!"));
        video2.AddComment(new Comment("Emma", "My favorite player scored."));
        video2.AddComment(new Comment("Frank", "Awesome video."));
        videos.Add(video2);

        Video video3 = new Video("Travel in Chile", "Adventure World", 900);
        video3.AddComment(new Comment("Grace", "Beautiful places."));
        video3.AddComment(new Comment("Henry", "I want to visit someday."));
        video3.AddComment(new Comment("Isabella", "Excellent guide."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}