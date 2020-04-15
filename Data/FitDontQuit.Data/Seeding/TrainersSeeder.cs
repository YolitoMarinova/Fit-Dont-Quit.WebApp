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

            Trainer firstTrainer = new Trainer
            {
                FirstName = "Georgi",
                LastName = "Filchev",
                Age = 29,
                Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
                PhoneNumber = "+359000000000",
                ImageUrl = "https://res.cloudinary.com/fit-dont-quit/image/upload/v1586948316/Trainers/trainer-1_b3elaq.jpg",
                InstagramUrl = "https://www.instagram.com/?hl=bg",
                ProfessionId = 2,
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
                ProfessionId = 3,
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
                ProfessionId = 2,
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
                ProfessionId = 3,
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
                ProfessionId = 2,
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
