using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Models.DTO;
using CodePluse.API.Respo.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePluse.API.Respo.Services
{
    public class BlogPostServices : IBlogPost
    {
        public readonly DbHelper dbHelper;
        public BlogPostServices(DbHelper _dbHelper)
        {
            this.dbHelper = _dbHelper;
        }
        public async Task<BlogPost> BlogPostAsync(BlogPost blogpost)
        {
            await dbHelper.BlogPosts.AddAsync(blogpost);
            await dbHelper.SaveChangesAsync();  
            return blogpost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPost()
        {
            return await dbHelper.BlogPosts.Include(x=>x.Categories).ToListAsync();
        }

        public async Task<BlogPost?> GetAllPostByid(Guid Id)
        {
           return await dbHelper.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<BlogPost?> UpdateBlogPost(BlogPost blogpost)
        {
            var res = await dbHelper.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id ==blogpost.Id);
            if (res != null)
            {
                //Update BlogPost
                dbHelper.Entry(res).CurrentValues.SetValues(blogpost);
                //Update Category Also
                res.Categories=blogpost.Categories;
                await dbHelper.SaveChangesAsync();
                return blogpost;

            }
            return null;
        }
        public async Task<BlogPost?> Delete(Guid Id)
        {
            var res = await dbHelper.BlogPosts.FirstOrDefaultAsync(x => x.Id == Id);
            if (res == null) { return null; }
            dbHelper.BlogPosts.Remove(res);
            await dbHelper.SaveChangesAsync();
            return res;

        }

        public async Task<BlogPost?> GetAllPostByUrl(string urlHandle)
        {
            return await dbHelper.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
    }
}
