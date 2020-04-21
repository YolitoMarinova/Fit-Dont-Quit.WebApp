namespace FitDontQuit.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;

    public class TrainersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Trainers.Any())
            {
                return;
            }

            var firstProfession = dbContext.Professions.FirstOrDefault(p => p.Name == "Personal trainer");
            var secondProfession = dbContext.Professions.FirstOrDefault(p => p.Name == "Zumba trainer");
            var thirdProfession = dbContext.Professions.FirstOrDefault(p => p.Name == "Yoga guru");
            var fourthProfession = dbContext.Professions.FirstOrDefault(p => p.Name == "Kick box trainer");
            var fifthProfession = dbContext.Professions.FirstOrDefault(p => p.Name == "Pilates trainer");

            Trainer firstTrainer = new Trainer
            {
                FirstName = "Georgi",
                LastName = "Filchev",
                Age = 29,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-1_b3elaq.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = firstProfession.Id,
            };

            Trainer secondTrainer = new Trainer
            {
                FirstName = "Emanuela",
                LastName = "Petrova",
                Age = 29,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-3_mlvfip.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = secondProfession.Id,
            };

            Trainer thirdTrainer = new Trainer
            {
                FirstName = "Michel",
                LastName = "Petrov",
                Age = 29,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-2_q09z17.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = thirdProfession.Id,
            };

            Trainer fourthTrainer = new Trainer
            {
                FirstName = "Melisa",
                LastName = "Ivanova",
                Age = 23,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-3_mlvfip.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = fourthProfession.Id,
            };

            Trainer fiveTrainer = new Trainer
            {
                FirstName = "Teodor",
                LastName = "Mladenov",
                Age = 33,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-2_q09z17.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = fifthProfession.Id,
            };

            await dbContext.Trainers.AddAsync(firstTrainer);
            await dbContext.Trainers.AddAsync(secondTrainer);
            await dbContext.Trainers.AddAsync(thirdTrainer);
            await dbContext.Trainers.AddAsync(fourthTrainer);
            await dbContext.Trainers.AddAsync(fiveTrainer);

            await dbContext.SaveChangesAsync();
        }
    }
}
