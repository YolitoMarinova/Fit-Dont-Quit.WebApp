namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var firstUser = new ApplicationUser
            {
                FirstName = "Yoana",
                LastName = "Marinova",
                UserName = "Yolito",
                Email = "marinova.m.y@gmail.com",
                EmailConfirmed = true,
            };

            var secondUser = new ApplicationUser
            {
                FirstName = "Georgi",
                LastName = "Filchev",
                UserName = "Gochko91",
                Email = "gosho@gcb.com",
                EmailConfirmed = true,
            };

            var thirdUser = new ApplicationUser
            {
                FirstName = "Zlatina",
                LastName = "Marinova",
                UserName = "Zlati",
                Email = "zlatito@pop.com",
                EmailConfirmed = true,
            };

            await SeedUserAsync(userManager, firstUser);
            await SeedUserAsync(userManager, secondUser);
            await SeedUserAsync(userManager, thirdUser);

            await userManager.AddToRoleAsync(secondUser, GlobalConstants.UserRoleName);
            await userManager.AddToRoleAsync(thirdUser, GlobalConstants.UserRoleName);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            var userExist = await userManager.FindByNameAsync(user.UserName);
            if (userExist == null)
            {
                var result = await userManager.CreateAsync(user, "123456");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
