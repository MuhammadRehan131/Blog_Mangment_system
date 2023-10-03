using CodePluse.API.Models.Domain;
using CodePluse.API.Models.DTO;
using CodePluse.API.Respo.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePluse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        public readonly IBlogPost blogPost;
        private readonly ICategory _icategory;

        public BlogPostController(IBlogPost _blogpost,ICategory category)
        {
                blogPost= _blogpost;
            this._icategory = category;
        }
        [Route("CreateBlogPosts")]
        [HttpPost]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> CreateBlogPosts([FromBody]CreateBlogPostRequestDTo obj)
        {
            //convert DTO to Domain
            var blogpost = new BlogPost
            {
                Author = obj.Author,
                Content = obj.Content,
                FeatureImaheUrl = obj.FeatureImaheUrl,  
                IsVisable = obj.IsVisable,              
                PublishedDate = obj.PublishedDate,
                Discription = obj.Discription,          
                UrlHandle = obj.UrlHandle,
                Title = obj.Title,
                Categories = new List<Category>()
            };

            foreach (var categoryGuid in obj.Categories)  
            {
                var existCategory = await _icategory.GetAllCategoriesByi(categoryGuid);  
                if (existCategory != null)
                {
                    blogpost.Categories.Add(existCategory);
                }
            }



            blogpost = await blogPost.BlogPostAsync(blogpost);
            var res = new CreateBlogPost
            {
                Id = blogpost.Id,
                Author = blogpost.Author,
                Content = blogpost.Content,
                FeatureImaheUrl = blogpost.FeatureImaheUrl,
                IsVisable = blogpost.IsVisable,
                PublishedDate = blogpost.PublishedDate,
                Discription = blogpost.Discription,
                UrlHandle = blogpost.UrlHandle,
                Title = blogpost.Title,
                Categories = blogpost.Categories.Select(x => new CreateCategoryDTO {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,

                }).ToList()

            };
            return Ok(res);
        }

        [Route("GetAllBlogPost")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var Post = await blogPost.GetAllBlogPost();
            var res = new List<CreateBlogPost>();
            foreach (var blogpost in Post)
            {
                res.Add(new CreateBlogPost
                {
                    Id = blogpost.Id,
                    Author = blogpost.Author,
                    Content = blogpost.Content,
                    Discription= blogpost.Discription,
                    PublishedDate= blogpost.PublishedDate,
                    Title = blogpost.Title,
                    UrlHandle= blogpost.UrlHandle,
                    FeatureImaheUrl= blogpost.FeatureImaheUrl,  
                    IsVisable= blogpost.IsVisable,
                    Categories = blogpost.Categories.Select(x => new CreateCategoryDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UrlHandle = x.UrlHandle,

                    }).ToList()
                });
            }
            return Ok(res);
            

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetBlogPostById([FromRoute] Guid id)
        {
            var res=await blogPost.GetAllPostByid(id);
            if (res ==null)
            {
                return NotFound();
            }
            var resp = new CreateBlogPost
            {
                Id = res.Id,
                Author = res.Author,
                Content = res.Content,
                Discription = res.Discription,
                PublishedDate = res.PublishedDate,
                Title = res.Title,
                UrlHandle = res.UrlHandle,
                FeatureImaheUrl = res.FeatureImaheUrl,
                IsVisable = res.IsVisable,
                Categories = res.Categories.Select(x => new CreateCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,

                }).ToList()
            };
            return Ok(resp);
        }
        [HttpGet]
        [Route("{urlHandle}")]
        public async Task<IActionResult> GetBlogPostByUrl([FromRoute] string urlHandle)
        {
            var res=await blogPost.GetAllPostByUrl(urlHandle);
            if (res == null)
            {
                return NotFound();
            }
            var resp = new CreateBlogPost
            {
                Id = res.Id,
                Author = res.Author,
                Content = res.Content,
                Discription = res.Discription,
                PublishedDate = res.PublishedDate,
                Title = res.Title,
                UrlHandle = res.UrlHandle,
                FeatureImaheUrl = res.FeatureImaheUrl,
                IsVisable = res.IsVisable,
                Categories = res.Categories.Select(x => new CreateCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,

                }).ToList()
            };
            return Ok(resp);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateBlogPost([FromRoute] Guid id, UpdateBlogPostDTO request)
        {
            // contver DTO to Domain
            var blogpost = new BlogPost
            {
                Id = id,
                Author = request.Author,
                Content = request.Content,
                FeatureImaheUrl = request.FeatureImaheUrl,
                IsVisable = request.IsVisable,
                PublishedDate = request.PublishedDate,
                Discription = request.Discription,
                UrlHandle = request.UrlHandle,
                Title = request.Title,
                Categories = new List<Category>()
            };
            foreach (var categoryGuid in request.Categories) {
                var exsitingCategory = await _icategory.GetAllCategoriesByi(categoryGuid);
                if (exsitingCategory !=null)
                {
                    blogpost.Categories.Add(exsitingCategory);
                }

            }


            var UpdateedblogPost = await blogPost.UpdateBlogPost(blogpost);
            if (UpdateedblogPost is null) { return NotFound(); }
            var res = new CreateBlogPost
            {
                Id = blogpost.Id,
                Author = blogpost.Author,
                Content = blogpost.Content,
                FeatureImaheUrl = blogpost.FeatureImaheUrl,
                IsVisable = blogpost.IsVisable,
                PublishedDate = blogpost.PublishedDate,
                Discription = blogpost.Discription,
                UrlHandle = blogpost.UrlHandle,
                Title = blogpost.Title,
                Categories = blogpost.Categories.Select(x => new CreateCategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlHandle = x.UrlHandle,

                }).ToList()

            };
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var blogpost = await blogPost.Delete(id);
            if (blogpost is null)
            {
                return NotFound();
            }
            //covert domain to dto
            var res = new CreateBlogPost
            {
                Id = blogpost.Id,
                Author = blogpost.Author,
                Content = blogpost.Content,
                FeatureImaheUrl = blogpost.FeatureImaheUrl,
                IsVisable = blogpost.IsVisable,
                PublishedDate = blogpost.PublishedDate,
                Discription = blogpost.Discription,
                UrlHandle = blogpost.UrlHandle,
                Title = blogpost.Title
              
            };
            return Ok(res);

        }
    }
}
