namespace FitDontQuit.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using FitDontQuit.Data;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Data.Repositories;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;
    using FitDontQuit.Web.ViewModels;
    using FitDontQuit.Web.ViewModels.Memberships;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class MembershipsServiceTests
    {
        [Fact]
        public async Task GetByIdReturnEntityWhenExistElementWIthGivenId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MembershipGetByIdDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Memberships
                .AddAsync(new Membership
                {
                    Id = 1,
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            this.InitializeMapper();

            var result = service.GetById<MembershipViewModel>(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByNameReturnEntitiesWithGivenNamesCountOfTimes()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MembershipGetByNameDb").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Memberships
                .AddRange(
                new Membership { Id = 1, Name = "FirstName" },
                new Membership { Id = 2, Name = "SecondName" },
                new Membership { Id = 3, Name = "ThirdName" });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(MembershipServiceOutputModel).GetTypeInfo().Assembly);

            var result = service.GetByNames<MembershipViewModel>(new[] { "FirstName", "ThirdName" });

            Assert.NotNull(result);
            Assert.Collection(
                result,
                x => Assert.Contains("FirstName", x.Name),
                x => Assert.Contains("ThirdName", x.Name));
        }

        [Fact]
        public async Task GetAllReturnAllEntities()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MembershipsGetAllDb").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Memberships.AddRange(
                          new Membership(),
                          new Membership(),
                          new Membership());

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            this.InitializeMapper();

            var result = service.GetAll<MembershipViewModel>();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MembershipsCreateDb").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            this.InitializeMapper();

            var expectedMembership = new Membership
            {
                Id = 1,
                Name = "Name",
                Price = 50,
                Duration = Duration.OneMonth,
                HaveATrainer = false,
                AmountOfPeopleLimit = AmountOfPeopleLimit.One,
                VisitLimit = VisitLimit.OnePerDay,
            };

            await service.CreateAsync(new CreateMembershipInputModel
            {
                Name = "Name",
                Price = 50,
                Duration = Duration.OneMonth,
                HaveATrainer = false,
                AmountOfPeopleLimit = AmountOfPeopleLimit.One,
                VisitLimit = VisitLimit.OnePerDay,
            });

            var actualMembership = dbContext.Memberships.FirstOrDefault(x => x.Name == "Name");

            Assert.NotNull(actualMembership);
            Assert.Equal(expectedMembership.Id, actualMembership.Id);
            Assert.Equal(expectedMembership.Name, actualMembership.Name);
            Assert.Equal(expectedMembership.Price, actualMembership.Price);
            Assert.Equal(expectedMembership.HaveATrainer, actualMembership.HaveATrainer);
            Assert.Equal(expectedMembership.Duration, actualMembership.Duration);
            Assert.Equal(expectedMembership.AmountOfPeopleLimit, actualMembership.AmountOfPeopleLimit);
            Assert.Equal(expectedMembership.VisitLimit, actualMembership.VisitLimit);
        }

        [Fact]
        public async Task EditAsyncShouldEditCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MembershipsEditDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Memberships.AddAsync(
                new Membership
                {
                    Id = 1,
                    Name = "Name",
                    Price = 50,
                    Duration = Duration.OneMonth,
                    HaveATrainer = false,
                    AmountOfPeopleLimit = AmountOfPeopleLimit.One,
                    VisitLimit = VisitLimit.OnePerDay,
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            var editModel = new EditMembershipInputModel
            {
                Name = "NewName",
                Price = 100,
                HaveATrainer = true,
                Duration = Duration.OneYear,
                AmountOfPeopleLimit = AmountOfPeopleLimit.Two,
                VisitLimit = VisitLimit.Unlimited,
            };

            await service.EditAsync(1, editModel);

            var result = dbContext.Memberships.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(result);
            Assert.Equal("NewName", result.Name);
            Assert.Equal(100, result.Price);
            Assert.True(result.HaveATrainer);
            Assert.Equal(Duration.OneYear, result.Duration);
            Assert.Equal(AmountOfPeopleLimit.Two, result.AmountOfPeopleLimit);
            Assert.Equal(VisitLimit.Unlimited, result.VisitLimit);
        }

        [Fact]
        public async Task DeleteShouldDeleteCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "MembershipsDeleteDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Memberships.AddAsync(new Membership { Id = 1 });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Membership>(dbContext);

            var service = new MembershipsService(repository);

            await service.DeleteAsync(1);

            var membership = dbContext.Memberships.FirstOrDefault(x => x.Id == 1);

            Assert.Null(membership);
        }

        private void InitializeMapper()
           => AutoMapperConfig.RegisterMappings(
               typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(CreateMembershipInputModel).GetTypeInfo().Assembly);

    }
}
