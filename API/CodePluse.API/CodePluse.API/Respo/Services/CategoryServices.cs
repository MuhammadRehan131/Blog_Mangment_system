using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Respo.IServices;
using Microsoft.EntityFrameworkCore;

namespace CodePluse.API.Respo.Services
{
    public class CategoryServices : ICategory
    {
        private readonly DbHelper _dbHelper;

        public CategoryServices(DbHelper dbHelper)
        {
            this._dbHelper = dbHelper;
        }
        public async Task<Category> CategoryAsync(Category category)
        {
            await _dbHelper.Categories.AddAsync(category);
            await _dbHelper.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> Delete(Guid Id)
        {
            var res=await _dbHelper.Categories.FirstOrDefaultAsync(x=>x.Id==Id);
            if (res==null) { return null; }
           _dbHelper.Categories.Remove(res);
            await _dbHelper.SaveChangesAsync();
            return res;

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbHelper.Categories.ToListAsync();
        }

        public async Task<Category?> GetAllCategoriesByi(Guid Id)
        {
          return await _dbHelper.Categories.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Category?> UpdateCategory(Category category)
        { 
            var res=await _dbHelper.Categories.FirstOrDefaultAsync(x=>x.Id==category.Id);
            if (res!=null)
            {
                _dbHelper.Entry(res).CurrentValues.SetValues(category);
                await _dbHelper.SaveChangesAsync();
                return category;

            }
            return null;
        }



        //public async Task<Category> UpdateCategory(int ID)
        //{
        //    if (ID > 0)
        //    {
        //        var res =await _dbHelper.Categories.FirstOrDefaultAsync(x=>x.Id == ID);
        //    }
        //}
    }
}
