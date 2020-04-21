namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;

    public class ProfessionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Professions.Any())
            {
                return;
            }

            var firstProfession = new Profession
            {
                Name = "Personal trainer",
            };

            var secondProfession = new Profession
            {
                Name = "Zumba trainer",
            };

            var thirdProfession = new Profession
            {
                Name = "Yoga guru",
            };

            var fourthProfession = new Profession
            {
                Name = "Kick box trainer",
            };

            var fiveProfession = new Profession
            {
                Name = "Pilates trainer",
            };

            await dbContext.Professions.AddAsync(firstProfession);
            await dbContext.Professions.AddAsync(secondProfession);
            await dbContext.Professions.AddAsync(thirdProfession);
            await dbContext.Professions.AddAsync(fourthProfession);
            await dbContext.Professions.AddAsync(fiveProfession);

            await dbContext.SaveChangesAsync();
        }
    }
}
