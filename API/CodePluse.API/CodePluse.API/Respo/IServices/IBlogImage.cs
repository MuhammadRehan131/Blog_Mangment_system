using CodePluse.API.Models.Domain;

namespace CodePluse.API.Respo.IServices
{
    public interface IBlogImage
    {
        Task<BlogImages> Upload(BlogImages image,IFormFile file);
        Task<IEnumerable<BlogImages>> GetAllBlogPostImages();
    }
}
