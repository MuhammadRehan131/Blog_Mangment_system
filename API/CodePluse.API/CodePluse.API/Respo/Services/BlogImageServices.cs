using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Respo.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Net.Mime.MediaTypeNames;

namespace CodePluse.API.Respo.Services
{
    public class BlogImageServices : IBlogImage
    {
        private readonly DbHelper _dbHelper;

        

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BlogImageServices(DbHelper dbHelper,IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
           
             _dbHelper = dbHelper;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        

        public async Task<IEnumerable<BlogImages>> GetAllBlogPostImages()
        {
            return await _dbHelper.BlogImage.ToListAsync();
        }

        public async Task<BlogImages> Upload(BlogImages image, IFormFile file)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtionsion}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);
            var requesthttp = httpContextAccessor.HttpContext.Request;
            var UrlPath = $"{requesthttp.Scheme}://{requesthttp.Host}{requesthttp.PathBase}/Images/{image.FileName}{image.FileExtionsion }";
            image.Url = UrlPath;
            await _dbHelper.BlogImage.AddAsync(image);
            await _dbHelper.SaveChangesAsync();
            return image;
        }

        
    }
}
