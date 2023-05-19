using LocalWise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LocalWise.Data
{
    public class SeedData
    {
        public static void Initialize(LWDbContext dbContext)
        {
            if(!dbContext.Users.Any())
            {
                var localWise = new Pessoa
                {
                    UserName = "Luiz_Celio",
                    Email = "luizceliogf@hotmail.com"
                };
                var password = "Segredo";

                var userManager = dbContext.GetService<UserManager<Pessoa>>();
                var roleManager = dbContext.GetService<RoleManager<IdentityRole>>();

                var localWiseRole = new IdentityRole(UserRoles.LocalWise);

                roleManager.CreateAsync(localWiseRole).Wait();

                //localWise.Roles.Add(new IdentityUserRole<string>
                //{
                //    RoleId = localWiseRole.Id
                //});

                userManager.CreateAsync(localWise, password).Wait();
            }
            dbContext.SaveChanges();
        }
    }
}
