using FitDontQuit.Data.Models;
using FitDontQuit.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitDontQuit.Data.Seeding
{
    public class ClassesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Classes.Any())
            {
                return;
            }

            var kangopJumps = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Kangoo Jumps");
            var spining = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Spining");
            var crossfit = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Crossfit");
            var fitBall = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Fit ball");
            var tapOut = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "TapOut");
            var pilates = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Pilates");
            var zumba = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Zumba");
            var aerobics = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Aerobics");
            var kickBox = dbContext.GroupTrainings.FirstOrDefault(x => x.Name == "Kick Box");

            var firstTrainer = dbContext.Trainers.FirstOrDefault(x => x.FirstName == "Georgi" && x.LastName == "Filchev");
            var secondTrainer = dbContext.Trainers.FirstOrDefault(x => x.FirstName == "Emanuela" && x.LastName == "Petrova");
            var thirdTrainer = dbContext.Trainers.FirstOrDefault(x => x.FirstName == "Michel" && x.LastName == "Petrov");
            var fourthTrainer = dbContext.Trainers.FirstOrDefault(x => x.FirstName == "Melisa" && x.LastName == "Ivanova");
            var fifthTrainer = dbContext.Trainers.FirstOrDefault(x => x.FirstName == "Teodor" && x.LastName == "Mladenov");

            var firstClass = new Class
            {
                StartHour = Hour.Ten,
                EndHour = Hour.Eleven,
                DayOfWeek = DayOfWeek.Monday,
                Capacity = 30,
                GroupTraining = kangopJumps,
                Trainer = firstTrainer,
            };

            var secondClass = new Class
            {
                StartHour = Hour.Twelve,
                EndHour = Hour.Thirteen,
                DayOfWeek = DayOfWeek.Monday,
                Capacity = 30,
                GroupTraining = spining,
                Trainer = secondTrainer,
            };

            var thirdClass = new Class
            {
                StartHour = Hour.Sixteen,
                EndHour = Hour.Seventeen,
                DayOfWeek = DayOfWeek.Monday,
                Capacity = 30,
                GroupTraining = crossfit,
                Trainer = thirdTrainer,
            };

            var fourthClass = new Class
            {
                StartHour = Hour.Ten,
                EndHour = Hour.Eleven,
                DayOfWeek = DayOfWeek.Tuesday,
                Capacity = 50,
                GroupTraining = pilates,
                Trainer = fourthTrainer,
            };

            var fifthClass = new Class
            {
                StartHour = Hour.Sixteen,
                EndHour = Hour.Eighteen,
                DayOfWeek = DayOfWeek.Tuesday,
                Capacity = 15,
                GroupTraining = fitBall,
                Trainer = fifthTrainer,
            };

            var sixthClass = new Class
            {
                StartHour = Hour.Thirteen,
                EndHour = Hour.Fourtheen,
                DayOfWeek = DayOfWeek.Tuesday,
                Capacity = 30,
                GroupTraining = tapOut,
                Trainer = firstTrainer,
            };

            var seventhClass = new Class
            {
                StartHour = Hour.Nine,
                EndHour = Hour.Eleven,
                DayOfWeek = DayOfWeek.Wednesday,
                Capacity = 30,
                GroupTraining = aerobics,
                Trainer = thirdTrainer,
            };

            var eightClass = new Class
            {
                StartHour = Hour.Eighteen,
                EndHour = Hour.Seventeen,
                DayOfWeek = DayOfWeek.Wednesday,
                Capacity = 30,
                GroupTraining = kickBox,
                Trainer = firstTrainer,
            };

            var ninethClass = new Class
            {
                StartHour = Hour.Twelve,
                EndHour = Hour.Fourtheen,
                DayOfWeek = DayOfWeek.Wednesday,
                Capacity = 50,
                GroupTraining = zumba,
                Trainer = fourthTrainer,
            };

            var tenClass = new Class
            {
                StartHour = Hour.Sixteen,
                EndHour = Hour.Seventeen,
                DayOfWeek = DayOfWeek.Thursday,
                Capacity = 30,
                GroupTraining = tapOut,
                Trainer = fifthTrainer,
            };

            var elevenClass = new Class
            {
                StartHour = Hour.Eighteen,
                EndHour = Hour.Ninetheen,
                DayOfWeek = DayOfWeek.Thursday,
                Capacity = 30,
                GroupTraining = spining,
                Trainer = thirdTrainer,
            };

            var twelveClass = new Class
            {
                StartHour = Hour.TwentyOne,
                EndHour = Hour.TwentyTwo,
                DayOfWeek = DayOfWeek.Thursday,
                Capacity = 30,
                GroupTraining = crossfit,
                Trainer = secondTrainer,
            };

            var thirtheenClass = new Class
            {
                StartHour = Hour.Nine,
                EndHour = Hour.Ten,
                DayOfWeek = DayOfWeek.Friday,
                Capacity = 20,
                GroupTraining = aerobics,
                Trainer = secondTrainer,
            };

            var fourtheenClass = new Class
            {
                StartHour = Hour.Twenty,
                EndHour = Hour.TwentyOne,
                DayOfWeek = DayOfWeek.Friday,
                Capacity = 30,
                GroupTraining = kangopJumps,
                Trainer = fifthTrainer,
            };

            var fivtheenClass = new Class
            {
                StartHour = Hour.Twelve,
                EndHour = Hour.Thirteen,
                DayOfWeek = DayOfWeek.Friday,
                Capacity = 20,
                GroupTraining = kickBox,
                Trainer = firstTrainer,
            };

            var sixtheenClass = new Class
            {
                StartHour = Hour.Eleven,
                EndHour = Hour.Twelve,
                DayOfWeek = DayOfWeek.Saturday,
                Capacity = 30,
                GroupTraining = aerobics,
                Trainer = firstTrainer,
            };

            var seventheenClass = new Class
            {
                StartHour = Hour.Eighteen,
                EndHour = Hour.Ninetheen,
                DayOfWeek = DayOfWeek.Saturday,
                Capacity = 50,
                GroupTraining = tapOut,
                Trainer = secondTrainer,
            };

            var eighteenClass = new Class
            {
                StartHour = Hour.TwentyOne,
                EndHour = Hour.TwentyTwo,
                DayOfWeek = DayOfWeek.Saturday,
                Capacity = 30,
                GroupTraining = zumba,
                Trainer = thirdTrainer,
            };

            var ninetheenClass = new Class
            {
                StartHour = Hour.Nine,
                EndHour = Hour.Eleven,
                DayOfWeek = DayOfWeek.Sunday,
                Capacity = 30,
                GroupTraining = kangopJumps,
                Trainer = fourthTrainer,
            };

            var twentyClass = new Class
            {
                StartHour = Hour.Thirteen,
                EndHour = Hour.Fourtheen,
                DayOfWeek = DayOfWeek.Sunday,
                Capacity = 30,
                GroupTraining = zumba,
                Trainer = fifthTrainer,
            };

            var twentyOneClass = new Class
            {
                StartHour = Hour.Seventeen,
                EndHour = Hour.Eighteen,
                DayOfWeek = DayOfWeek.Sunday,
                Capacity = 15,
                GroupTraining = kickBox,
                Trainer = fifthTrainer,
            };

            await dbContext.Classes.AddAsync(firstClass);
            await dbContext.Classes.AddAsync(secondClass);
            await dbContext.Classes.AddAsync(thirdClass);
            await dbContext.Classes.AddAsync(fourthClass);
            await dbContext.Classes.AddAsync(fifthClass);
            await dbContext.Classes.AddAsync(sixthClass);
            await dbContext.Classes.AddAsync(seventhClass);
            await dbContext.Classes.AddAsync(eightClass);
            await dbContext.Classes.AddAsync(ninethClass);
            await dbContext.Classes.AddAsync(tenClass);
            await dbContext.Classes.AddAsync(elevenClass);
            await dbContext.Classes.AddAsync(twelveClass);
            await dbContext.Classes.AddAsync(thirtheenClass);
            await dbContext.Classes.AddAsync(fourtheenClass);
            await dbContext.Classes.AddAsync(fivtheenClass);
            await dbContext.Classes.AddAsync(sixtheenClass);
            await dbContext.Classes.AddAsync(seventheenClass);
            await dbContext.Classes.AddAsync(eighteenClass);
            await dbContext.Classes.AddAsync(ninetheenClass);
            await dbContext.Classes.AddAsync(twentyClass);
            await dbContext.Classes.AddAsync(twentyOneClass);

            await dbContext.SaveChangesAsync();
        }
    }
}
