namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;

    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> hallsRepository;

        public HallsService(IDeletableEntityRepository<Hall> hallsRepository)
        {
            this.hallsRepository = hallsRepository;
        }

        public async Task CreateAsync(HallServiceInputModel hallModel)
        {
            var hall = new Hall
            {
                Name = hallModel.Name,
                SeatsCount = hallModel.SeatsCount,
            };

            await this.hallsRepository.AddAsync(hall);
            await this.hallsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, HallServiceInputModel hallModel)
        {
            var hall = this.hallsRepository.All().Where(h => h.Id == id).FirstOrDefault();

            hall.Name = hallModel.Name;
            hall.SeatsCount = hallModel.SeatsCount;

            await this.hallsRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hall = this.hallsRepository.All().FirstOrDefault(h => h.Id == id);

            if (hall == null)
            {
                return false;
            }

            this.hallsRepository.Delete(hall);
            await this.hallsRepository.SaveChangesAsync();

            return true;
        }

        public T GetById<T>(int id)
        {
            var hall = this.hallsRepository.All().Where(h => h.Id == id).To<HallServiceOutputModel>().FirstOrDefault();

            var hallT = AutoMapperConfig.MapperInstance.Map<T>(hall);

            return hallT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var halls = this.hallsRepository.All().To<HallServiceOutputModel>();

            var hallsT = halls.To<T>().ToList();

            return hallsT;
        }
    }
}
