namespace CodePluse.API.Models.DTO
{
    public class CreateBlogPostRequestDTo
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Content { get; set; }
        public string FeatureImaheUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisable { get; set; }
        public Guid[] Categories { get; set; }
    }
}
