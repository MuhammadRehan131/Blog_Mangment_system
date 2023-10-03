using CodePluse.API.Models.DTO;
using CodePluse.API.Respo.IServices;
using CodePluse.API.Respo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodePluse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
         
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenAuth _tokenAuthServices;
        public AuthController(UserManager<IdentityUser> userManager, ITokenAuth tokenAuthServices)
        {
          _userManager = userManager;
            _tokenAuthServices = tokenAuthServices;


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginrequestDTO request)
        {
            var res= await _userManager.FindByEmailAsync(request.Email);
            if (res is not null)
            {
                 //checked Password
               var checkPass=  await _userManager.CheckPasswordAsync(res,request.Password);
                if (checkPass)
                {
                    var roles = await _userManager.GetRolesAsync(res);
                    //Create a Token Request
                   var JwtToken= _tokenAuthServices.CreateJWTToken(res,roles.ToList());

                    var responce=new LoginResponceDTO 
                    {
                        Email=request.Email,
                        Roles=roles.ToList(),
                        Token= JwtToken


                    };
                    return Ok(responce);
                }
                
            }
            ModelState.AddModelError("", "Email or Password Incorrect");
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("Rigesters")]
        public async Task<IActionResult> Rigester([FromBody] rigesterRequestDTO request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };
           var identityresult= await _userManager.CreateAsync(user,request.Password);
            if (identityresult.Succeeded)
            {
                identityresult = await _userManager.AddToRoleAsync(user, "Reader");
                if (identityresult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (identityresult.Errors.Any())
                    {
                        foreach (var error in identityresult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityresult.Errors.Any())
                {
                    foreach (var error in identityresult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ValidationProblem(ModelState);
        }



    }
}
