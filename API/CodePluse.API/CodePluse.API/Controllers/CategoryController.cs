using CodePluse.API.Data;
using CodePluse.API.Models.Domain;
using CodePluse.API.Models.DTO;
using CodePluse.API.Respo.IServices;
using CodePluse.API.Respo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePluse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _icategory;
        public CategoryController(ICategory icategory)
        {
            _icategory = icategory;
        }

        public DbHelper DbHelper { get; }
        [Route("CreateCategory")]
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateCategory(CategoryDTO dto)
        {
            //Map dto to Domain model
            var category = new Category { 
            Name = dto.Name,
            UrlHandle = dto.UrlHandle,
            };
           await  _icategory.CategoryAsync(category);
            //Domain model to DTO
            var res = new CreateCategoryDTO
            { 
            Id =category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle,

            };

            return Ok(res);
        }
        [Route("GetAll")]
        [HttpGet]
      
        public async Task<IActionResult> GetAll()
        {
           var categories= await _icategory.GetAllCategoriesAsync();
            //Map Domain model to Dto
            var response=new List<CreateCategoryDTO>();
            foreach (var obj in categories)
            {
                response.Add(new CreateCategoryDTO {
                    Id = obj.Id,
                    Name = obj.Name,
                    UrlHandle=obj.UrlHandle
                });
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetById([FromRoute]Guid id)
        {
            var res=await _icategory.GetAllCategoriesByi(id);
            if (res is null)
            {
                return NotFound();
            }
            var resp = new CreateCategoryDTO
            {
                Id = res.Id,
                Name = res.Name,
                UrlHandle = res.UrlHandle,
            };
            return Ok(resp);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult>UpdateCategory([FromRoute]Guid id, UpdateCategoryDTO res)
        {
            // contver DTO to Domain
            var category = new Category
            {
                Id = id,
                Name = res.Name,
                UrlHandle = res.UrlHandle,
            };
            category = await _icategory.UpdateCategory(category);
            if (res is null) { return NotFound(); }
            var obj = new CreateCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,

            };
            return Ok(obj);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult>Delete([FromRoute]Guid id)
        {
           var category=await _icategory.Delete(id);
            if (category is null)
            {
                return NotFound();
            }
            //covert domain to dto
            var res = new CreateCategoryDTO 
            { 
            
            Id=category.Id,
            Name = category.Name,
                UrlHandle = category.UrlHandle,
            
            };
            return Ok(res);

        }

    }
}
