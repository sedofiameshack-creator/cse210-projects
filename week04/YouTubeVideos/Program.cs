using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Unboxing the New Wireless Headphones", "TechReviews Daily", 612);
        video1.AddComment(new Comment("Alicia M.", "The sound quality looks amazing, definitely buying these!"));
        video1.AddComment(new Comment("DarnellG", "Did you notice the logo on the case? Nice placement."));
        video1.AddComment(new Comment("sam_the_gamer", "How's the battery life compared to the last model?"));
        video1.AddComment(new Comment("Priya K.", "Great review, very thorough as always."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Morning Routine for Productivity", "Wellness With Kate", 845);
        video2.AddComment(new Comment("JordanT", "That smoothie blender looks awesome, what brand is it?"));
        video2.AddComment(new Comment("Megan R.", "This actually motivated me to wake up earlier, thank you!"));
        video2.AddComment(new Comment("chris.b", "Love the water bottle, subscribed to find out where it's from."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Building a Budget Gaming PC in 2026", "CircuitCraft", 1320);
        video3.AddComment(new Comment("PixelPunk", "The RGB keyboard in the background is fire."));
        video3.AddComment(new Comment("Nadia L.", "Can you link the case fans you used?"));
        video3.AddComment(new Comment("Owen S.", "Great breakdown of the price to performance ratio."));
        video3.AddComment(new Comment("retrogamer99", "The monitor brand caught my eye immediately."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("A Week of Quick and Healthy Dinners", "Kitchen With Marcus", 734);
        video4.AddComment(new Comment("Tanya W.", "The knife set you're using looks really sharp and clean."));
        video4.AddComment(new Comment("BenH", "Making the stir fry tonight, thanks for the recipe!"));
        video4.AddComment(new Comment("Lucia F.", "Where did you get that cutting board? Love the design."));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}