namespace CodePluse.API.Models.DTO
{
    public class CreateBlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public string Content { get; set; }
        public string FeatureImaheUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisable { get; set; }


        public List<CreateCategoryDTO> Categories { get; set; } =new List<CreateCategoryDTO>();
    }
}
