using FitDontQuit.Data;
using FitDontQuit.Data.Models;
using FitDontQuit.Data.Repositories;
using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Memberships;
using FitDontQuit.Services.Models.Professions;
using FitDontQuit.Services.Models.Trainers;
using FitDontQuit.Web.ViewModels;
using FitDontQuit.Web.ViewModels.Trainers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FitDontQuit.Services.Data.Tests
{
    public class TrainersServiceTests
    {
        [Fact]
        public async Task GetByIdReturnEntityWhenExistElementWIthGivenId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TrainersGetByIdDb").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Trainers
                .Add(new Trainer
                {
                    Id = 1,
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Trainer>(dbContext);

            var service = new TrainersService(repository);

            this.InitializeMapper();

            var result = service.GetById<TrainerViewModel>(1);

            Assert.Equal(1, result.Id);
        }

        //[Fact]
        //public async Task GetByNameReturnEntitiesWithGivenNamesCountOfTimes()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    .UseInMemoryDatabase(databaseName: "TrainersGetByNameDb").Options;
        //    var dbContext = new ApplicationDbContext(options);

        //    dbContext.Memberships
        //        .AddRange(
        //        new Membership { Id = 1, Name = "FirstName" },
        //        new Membership { Id = 2, Name = "SecondName" },
        //        new Membership { Id = 3, Name = "ThirdName" });

        //    await dbContext.SaveChangesAsync();

        //    var repository = new EfDeletableEntityRepository<Membership>(dbContext);

        //    var service = new MembershipsService(repository);

        //    AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(TrainerServiceOutputModel).GetTypeInfo().Assembly);

        //    var result = service.GetByNames<MembershipViewModel>(new[] { "FirstName", "ThirdName" });

        //    Assert.NotNull(result);
        //    Assert.Collection(
        //        result,
        //        x => Assert.Contains("FirstName", x.Name),
        //        x => Assert.Contains("ThirdName", x.Name));
        //}

        [Fact]
        public async Task GetAllReturnAllEntities()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TrainersGetAllDb").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Trainers.AddRange(
                          new Trainer(),
                          new Trainer(),
                          new Trainer());

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Trainer>(dbContext);

            var service = new TrainersService(repository);

            this.InitializeMapper();

            var result = service.GetAll<TrainerViewModel>();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TrainersCreateDb").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Trainer>(dbContext);

            var service = new TrainersService(repository);

            await service.CreateAsync(new CreateTrainerInputModel
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Description = "Description",
                Age = 30,
                ImageUrl = "ImageUrl",
                InstagramUrl = "InstagramUrl",
                PhoneNumber = "0877777777",
                ProfessionId = 1,
            });

            var expectedTrainer = new Trainer
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Description = "Description",
                Age = 30,
                ImageUrl = "ImageUrl",
                InstagramUrl = "InstagramUrl",
                PhoneNumber = "0877777777",
                ProfessionId = 1,
            };

            var actualTrainer = dbContext
                .Trainers
                .FirstOrDefault(x => x.FirstName == "FirstName");

            Assert.NotNull(actualTrainer);
            Assert.Equal(expectedTrainer.Id, actualTrainer.Id);
            Assert.Equal(expectedTrainer.FirstName, actualTrainer.FirstName);
            Assert.Equal(expectedTrainer.LastName, actualTrainer.LastName);
            Assert.Equal(expectedTrainer.Description, actualTrainer.Description);
            Assert.Equal(expectedTrainer.Age, actualTrainer.Age);
            Assert.Equal(expectedTrainer.ImageUrl, actualTrainer.ImageUrl);
            Assert.Equal(expectedTrainer.InstagramUrl, actualTrainer.InstagramUrl);
            Assert.Equal(expectedTrainer.PhoneNumber, actualTrainer.PhoneNumber);
            Assert.Equal(expectedTrainer.ProfessionId, actualTrainer.ProfessionId);
        }

        [Fact]
        public async Task EditAsyncShouldEditCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TrainersEditDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Trainers.AddAsync(
                new Trainer
                {
                    Id = 1,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Description = "Description",
                    Age = 30,
                    ImageUrl = "ImageUrl",
                    InstagramUrl = "InstagramUrl",
                    PhoneNumber = "0877777777",
                    ProfessionId = 1,
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Trainer>(dbContext);

            var service = new TrainersService(repository);

            var editModel = new EditTrainerInputServiceModel
            {
                FirstName = "First",
                LastName = "Last",
                Description = "Description2",
                Age = 50,
                ImageUrl = "ImageUrl2",
                InstagramUrl = "InstagramUrl2",
                PhoneNumber = "088888888",
                ProfessionId = 2,
            };

            await service.EditAsync(1, editModel);

            var result = dbContext.Trainers.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(result);
            Assert.Equal("First", result.FirstName);
            Assert.Equal("Last", result.LastName);
            Assert.Equal("Description2", result.Description);
            Assert.Equal(50, result.Age);
            Assert.Equal("ImageUrl2", result.ImageUrl);
            Assert.Equal("InstagramUrl2", result.InstagramUrl);
            Assert.Equal("088888888", result.PhoneNumber);
            Assert.Equal(2, result.ProfessionId);
        }

        [Fact]
        public async Task DeleteShouldDeleteCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "TrainersDeleteDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Trainers.AddAsync(new Trainer { Id = 1 });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Trainer>(dbContext);

            var service = new TrainersService(repository);

            await service.DeleteAsync(1);

            var trainer = dbContext.Trainers.FirstOrDefault(x => x.Id == 1);

            Assert.Null(trainer);
        }

        private void InitializeMapper()
            => AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(CreateMembershipInputModel).GetTypeInfo().Assembly);

    }
}
