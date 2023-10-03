using CodePluse.API.Models.Domain;

namespace CodePluse.API.Respo.IServices
{
    public interface ICategory
    {
       Task<Category> CategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category?> GetAllCategoriesByi(Guid Id);
        Task<Category?> Delete(Guid Id);
        Task<Category?> UpdateCategory(Category category);
    }
}
