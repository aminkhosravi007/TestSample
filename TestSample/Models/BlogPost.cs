namespace TestSample.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
