using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePluse.API.Data
{
    public class AuthDbHelper : IdentityDbContext
    {
        public AuthDbHelper(DbContextOptions<AuthDbHelper> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readeRoleId = "bd8346cc-0535-4b96-909a-241d266b5713";
            var writerRoleId = "20d1979d-e633-4506-9b9e-9246d0b4d7c1";
            //Create Reader and Writer Roles
            var roles = new List<IdentityRole>
            {
            new IdentityRole()
              {
                Id = readeRoleId,
                Name = "Reader",
                NormalizedName="Reader".ToUpper(),
                ConcurrencyStamp=readeRoleId
              },
                 new IdentityRole()
                 {
                Id = writerRoleId,
                Name = "Writer",
                NormalizedName="Writer".ToUpper(),
                ConcurrencyStamp=writerRoleId
                }
            };

            //Seed the Roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create User
            var adminUserId = "c2a88b1e-7b3c-48d4-b699-8abca48140c3";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin",
                Email = "admin@codeplus.com",
                NormalizedEmail = "admin@codeplus.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),

            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@1234");

            builder.Entity<IdentityUser>().HasData(admin);
            //Give roles
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId= adminUserId,
                    RoleId=readeRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId=writerRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
