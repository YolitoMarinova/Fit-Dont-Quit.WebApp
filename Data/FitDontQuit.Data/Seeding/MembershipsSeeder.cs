namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;

    public class MembershipsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Memberships.Any())
            {
                return;
            }

            var firstMembership = new Membership
            {
                Name = "One week challenge",
                Price = 15,
                Duration = Duration.SevenDays,
                HaveATrainer = false,
                VisitLimit = VisitLimit.Unlimited,
            };

            var secondMembership = new Membership
            {
                Name = "Monthly challenge",
                Price = 35,
                Duration = Duration.OneMonth,
                HaveATrainer = false,
                VisitLimit = VisitLimit.Unlimited,
            };

            var thirdMembership = new Membership
            {
                Name = "Basic",
                Price = 80,
                Duration = Duration.ThreeMonths,
                HaveATrainer = false,
                VisitLimit = VisitLimit.Unlimited,
            };

            var fourthMembership = new Membership
            {
                Name = "Special",
                Price = 230,
                Duration = Duration.OneYear,
                HaveATrainer = true,
                VisitLimit = VisitLimit.Unlimited,
            };

            var fifthMembership = new Membership
            {
                Name = "Monthly",
                Price = 35,
                Duration = Duration.OneMonth,
                HaveATrainer = true,
                VisitLimit = VisitLimit.OnePerDay,
            };

            await dbContext.Memberships.AddAsync(firstMembership);
            await dbContext.Memberships.AddAsync(secondMembership);
            await dbContext.Memberships.AddAsync(thirdMembership);
            await dbContext.Memberships.AddAsync(fourthMembership);
            await dbContext.Memberships.AddAsync(fifthMembership);

            await dbContext.SaveChangesAsync();
        }
    }
}
