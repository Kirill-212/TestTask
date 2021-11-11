namespace TestWebApplication.Models
{
    public class Comment
    {
        public int CommentsId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Img Img { get; set; }
    }
}
