namespace FitDontQuit.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using FitDontQuit.Data;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Repositories;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;
    using FitDontQuit.Services.Models.Professions;
    using FitDontQuit.Web.ViewModels;
    using FitDontQuit.Web.ViewModels.Administration.Professions;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ProfessionsServiceTests
    {
        [Fact]
        public async Task GetByIdReturnEntityWhenExistElementWIthGivenId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProfessionGetByIdDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Professions
                .AddAsync(new Profession
                {
                    Id = 1,
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Profession>(dbContext);

            var service = new ProfessionService(repository);

            this.InitializeMapper();

            var result = service.GetById<ProfessionViewModel>(1);

            Assert.Equal(1, result.Id);
            Assert.IsType<ProfessionViewModel>(result);
        }

        [Fact]
        public async Task GetAllReturnAllEntities()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProfessionsGetAllDb").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Professions.AddRange(
                          new Profession(),
                          new Profession(),
                          new Profession());

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Profession>(dbContext);

            var service = new ProfessionService(repository);

            this.InitializeMapper();

            var result = service.GetAll<ProfessionViewModel>();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProfessionsCreateDb").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Profession>(dbContext);

            var service = new ProfessionService(repository);

            await service.CreateAsync(new ProfessionServiceInputModel
            {
                Name = "Profession",
            });

            var expectedProfession = new Profession { Id = 1, Name = "Profession" };

            var actualProfession = dbContext.Professions.FirstOrDefault(x => x.Name == "Profession");

            Assert.NotNull(actualProfession);
            Assert.Equal(expectedProfession.Id, actualProfession.Id);
            Assert.Equal(expectedProfession.Name, actualProfession.Name);
        }

        [Fact]
        public async Task EditAsyncShouldEditCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProfessionsEditDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Professions.AddAsync(
                new Profession
                {
                    Id = 1,
                    Name = "Name",
                });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Profession>(dbContext);

            var service = new ProfessionService(repository);

            var editModel = new ProfessionServiceInputModel
            {
                Name = "NewName",
            };

            await service.EditAsync(1, editModel);

            var result = dbContext.Professions.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(result);
            Assert.Equal("NewName", result.Name);
        }

        [Fact]
        public async Task DeleteShouldDeleteCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "ProfessionsDeleteDb").Options;
            var dbContext = new ApplicationDbContext(options);

            await dbContext.Professions.AddAsync(new Profession { Id = 1 });

            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Profession>(dbContext);

            var service = new ProfessionService(repository);

            await service.DeleteAsync(1);

            var profession = dbContext.Professions.FirstOrDefault(x => x.Id == 1);

            Assert.Null(profession);
        }
        
        private void InitializeMapper()
           => AutoMapperConfig.RegisterMappings(
               typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(CreateMembershipInputModel).GetTypeInfo().Assembly);

    }
}
