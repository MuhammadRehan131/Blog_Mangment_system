using CodePluse.API.Models.Domain;

namespace CodePluse.API.Respo.IServices
{
    public interface IBlogPost
    {
        Task<BlogPost> BlogPostAsync(BlogPost blogpost);
        Task<IEnumerable<BlogPost>> GetAllBlogPost();

        Task<BlogPost?> GetAllPostByid(Guid Id);
        Task<BlogPost?> GetAllPostByUrl(string urlHandle);
        Task<BlogPost?> Delete(Guid Id);
        Task<BlogPost?> UpdateBlogPost(BlogPost blogpost);
    }
}
