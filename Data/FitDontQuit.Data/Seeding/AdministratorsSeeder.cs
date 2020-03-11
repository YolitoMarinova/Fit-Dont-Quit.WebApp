namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FitDontQuit.Data.Models;
    using Microsoft.AspNetCore.Identity;

    using Microsoft.Extensions.DependencyInjection;
    public class AdministratorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "Yoana");
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Administrator");

            var exist = dbContext.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            if (exist)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id,
            });
        }
    }
}
