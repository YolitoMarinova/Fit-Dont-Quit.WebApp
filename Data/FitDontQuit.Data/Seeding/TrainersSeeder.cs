using FitDontQuit.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitDontQuit.Data.Seeding
{
    public class TrainersSeeder : ISeeder
    {
        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //First should add cloudinary

            //if (dbContext.Trainers.Any())
            //{
            //    return;
            //}

            //Trainer trainer = new Trainer 
            //{ 
            //    FirstName = "Georgi",
            //    LastName = "Filchev",
            //    Age = 29,
            //    Description = "non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.",
            //    PhoneNumber = ""
            //};

            return;
        }
    }
}
