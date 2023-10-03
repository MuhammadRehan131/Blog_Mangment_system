namespace CodePluse.API.Models.DTO
{
    public class UpdateBlogPostDTO
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Content { get; set; }
        public string FeatureImaheUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisable { get; set; }
        public List<Guid> Categories { get; set; }=new List <Guid>();
    }
}
