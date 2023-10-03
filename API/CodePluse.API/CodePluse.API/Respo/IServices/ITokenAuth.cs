using Microsoft.AspNetCore.Identity;

namespace CodePluse.API.Respo.IServices
{
    public interface ITokenAuth
    {
        string CreateJWTToken(IdentityUser user,List<string> roles);
    }
}
