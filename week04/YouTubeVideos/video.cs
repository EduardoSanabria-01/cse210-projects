// Video.cs

public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds;
    private List<Comment> _comments; // Private list to store comments

    // Constructor to initialize the video's main properties
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Initialize the comment list
    }

    // Method to add a new comment to the video
    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        _comments.Add(newComment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get the list of comments (for display purposes)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}