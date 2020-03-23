namespace FitDontQuit.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;

    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> hallsRepository;

        public HallsService(IDeletableEntityRepository<Hall> hallsRepository)
        {
            this.hallsRepository = hallsRepository;
        }

        public Task AddAsync(string hallModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
