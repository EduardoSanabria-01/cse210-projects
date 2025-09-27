// Comment.cs

public class Comment
{
    public string _commenterName;
    public string _commentText;

    // Constructor to easily create a new comment
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }
}