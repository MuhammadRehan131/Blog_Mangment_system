using CodePluse.API.Models.Domain;
using CodePluse.API.Models.DTO;
using CodePluse.API.Respo.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePluse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogImagesController : ControllerBase
    {
        private readonly IBlogImage blogImage;

        public BlogImagesController(IBlogImage blogImage)
        {
            this.blogImage = blogImage;
        }

        [Route("CreateBlogImages")]
        [HttpPost]
        public async Task<IActionResult> CreateBlogImages([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);
            if (ModelState.IsValid)
            {
                var blogPostImage = new BlogImages
                {
                    FileExtionsion = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCrested = DateTime.Now
                };
                blogPostImage = await blogImage.Upload(blogPostImage, file);


                var res = new BlogImageDTO
                {
                    Id = blogPostImage.Id,
                    Title = blogPostImage.Title,
                    FileExtionsion = blogPostImage.FileExtionsion,
                    FileName = blogPostImage.FileName,
                    Url = blogPostImage.Url,
                    DateCrested = blogPostImage.DateCrested

                };
                  return Ok(res);
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "UnSupported file formate");
            }
            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File Siza Can Not b greater the 10 MB");
            }



        }

        [Route("GetAllImags")]
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var res= await blogImage.GetAllBlogPostImages();

            var img = new List<BlogImageDTO>();
            foreach (var item in res)
            {
                img.Add(new BlogImageDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    FileExtionsion = item.FileExtionsion,
                    FileName = item.FileName,
                    Url = item.Url,
                    DateCrested = item.DateCrested
                });
            }
            return Ok(img);
             
        }


    }
}
