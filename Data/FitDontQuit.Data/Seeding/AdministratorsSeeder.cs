﻿namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using static FitDontQuit.Common.GlobalConstants;

    public class AdministratorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.FirstName == "Yoana");
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == AdministratorRoleName);

            var exist = dbContext.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            if (exist)
            {
                return;
            }

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id,
            });
        }
    }
}
