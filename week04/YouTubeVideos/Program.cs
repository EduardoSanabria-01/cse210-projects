// Program.cs

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all the video objects
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("C# Tutorial for Absolute Beginners", "CodeMaster", 950);
        video1.AddComment("Alice", "This was so helpful, thank you!");
        video1.AddComment("Bob", "I was stuck on loops, but this cleared it up.");
        video1.AddComment("Charlie", "Great pacing and clear explanations.");
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video("How to Make the Perfect Sourdough", "The Baker", 1832);
        video2.AddComment("David", "My starter finally worked because of this video.");
        video2.AddComment("Eve", "The crust on my bread was amazing!");
        video2.AddComment("Frank", "Can you do a video on whole wheat next?");
        video2.AddComment("Grace", "Best recipe I've found online.");
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("10 Minute Morning Yoga Flow", "YogaWithZoe", 615);
        video3.AddComment("Heidi", "Perfect way to start my day.");
        video3.AddComment("Ivan", "So relaxing. I feel ready for work.");
        video3.AddComment("Judy", "Love this routine!");
        videos.Add(video3);

        // --- Display all videos and their comments ---
        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();
            Console.WriteLine("Comments:");

            if (video.GetNumberOfComments() > 0)
            {
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment._commenterName}: \"{comment._commentText}\"");
                }
            }
            else
            {
                Console.WriteLine("  (No comments yet)");
            }
            Console.WriteLine(); // Add a blank line for readability
        }
    }
}