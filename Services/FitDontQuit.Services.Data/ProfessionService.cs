namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    public class ProfessionService : IProfessionsService
    {
        private readonly IDeletableEntityRepository<Profession> professionRepository;

        public ProfessionService(IDeletableEntityRepository<Profession> professionRepository)
        {
            this.professionRepository = professionRepository;
        }

        public async Task CreateAsync(ProfessionServiceInputModel professionModel)
        {
            var profession = new Profession { Name = professionModel.Name };

            await this.professionRepository.AddAsync(profession);
            await this.professionRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, ProfessionServiceInputModel professionModel)
        {
            var profession = this.professionRepository.All().Where(p => p.Id == id).FirstOrDefault();

            profession.Name = professionModel.Name;

            await this.professionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profession = this.professionRepository.All().FirstOrDefault(p => p.Id == id);

            this.professionRepository.Delete(profession);
            await this.professionRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var profession = this.professionRepository.All().Where(p => p.Id == id).To<ProfessionServiceOutputModel>().FirstOrDefault();

            var professionT = AutoMapperConfig.MapperInstance.Map<T>(profession);

            return professionT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var professions = this.professionRepository.All().To<ProfessionServiceOutputModel>();


            var professionsT = professions.To<T>().ToList();

            return professionsT;
        }
    }
}
