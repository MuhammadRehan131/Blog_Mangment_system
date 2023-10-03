using CodePluse.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodePluse.API.Data
{
    public class DbHelper : DbContext
    {
        public DbHelper(DbContextOptions<DbHelper> options) : base(options)
        {
        }

        public DbSet<BlogPost>BlogPosts { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<BlogImages>BlogImage { get; set; }

    }
}
