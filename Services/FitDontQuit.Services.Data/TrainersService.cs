namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;

    public class TrainersService : ITrainersService
    {
        private readonly IDeletableEntityRepository<Trainer> trainersRepository;

        public TrainersService(IDeletableEntityRepository<Trainer> trainersRepository)
        {
            this.trainersRepository = trainersRepository;
        }

        public async Task CreateAsync(CreateTrainerInputModel trainerModel)
        {
            var trainer = new Trainer
            {
                FirstName = trainerModel.FirstName,
                LastName = trainerModel.LastName,
                Description = trainerModel.Description,
                Age = trainerModel.Age,
                ImageUrl = trainerModel.ImageUrl,
                InstagramUrl = trainerModel.InstagramUrl,
                PhoneNumber = trainerModel.PhoneNumber,
                ProfessionId = trainerModel.ProfessionId,
            };

            await this.trainersRepository.AddAsync(trainer);
            await this.trainersRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditTrainerInputServiceModel trainerModel)
        {
            var trainer = this.trainersRepository.All().Where(t => t.Id == id).FirstOrDefault();

            trainer.FirstName = trainerModel.FirstName;
            trainer.LastName = trainerModel.LastName;
            trainer.Description = trainerModel.Description;
            trainer.Age = trainerModel.Age;
            if (trainerModel.ImageUrl != null)
            {
                trainer.ImageUrl = trainerModel.ImageUrl;
            }
            trainer.InstagramUrl = trainerModel.InstagramUrl;
            trainer.PhoneNumber = trainerModel.PhoneNumber;
            trainer.ProfessionId = trainerModel.ProfessionId;

            await this.trainersRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trainer = this.trainersRepository.All().FirstOrDefault(t => t.Id == id);

            this.trainersRepository.Delete(trainer);
            await this.trainersRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var trainer = this.trainersRepository.All().Where(t => t.Id == id).To<TrainerServiceOutputModel>().FirstOrDefault();

            var trainerT = AutoMapperConfig.MapperInstance.Map<T>(trainer);

            return trainerT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var trainers = this.trainersRepository.All().To<TrainerServiceOutputModel>();

            var trainersT = trainers.To<T>().ToList();

            return trainersT;
        }
    }
}
