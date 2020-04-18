namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;

    public class GroupTrainingsService : IGroupTrainingsService
    {
        private readonly IDeletableEntityRepository<GroupTraining> groupTrainingsRepository;

        public GroupTrainingsService(IDeletableEntityRepository<GroupTraining> groupTrainingsRepository)
        {
            this.groupTrainingsRepository = groupTrainingsRepository;
        }

        public async Task CreateAsync(CreateGroupTrainingServiceModel groupTrainingModel)
        {
            var groupTraining = new GroupTraining
            {
                Name = groupTrainingModel.Name,
                Description = groupTrainingModel.Description,
                ImageUrl = groupTrainingModel.ImageUrl,
            };

            await this.groupTrainingsRepository.AddAsync(groupTraining);
            await this.groupTrainingsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditGroupTrainingServiceModel groupTrainingModel)
        {
            var groupTraining = this.groupTrainingsRepository.All().Where(gt => gt.Id == id).FirstOrDefault();

            groupTraining.Name = groupTrainingModel.Name;
            groupTraining.Description = groupTrainingModel.Description;

            if (groupTrainingModel.ImageUrl != null)
            {
                groupTraining.ImageUrl = groupTrainingModel.ImageUrl;
            }

            await this.groupTrainingsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var groupTraining = this.groupTrainingsRepository.All().FirstOrDefault(gt => gt.Id == id);

            this.groupTrainingsRepository.Delete(groupTraining);
            await this.groupTrainingsRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var groupTraining = this.groupTrainingsRepository.All().Where(gt => gt.Id == id).To<GroupTrainingServiceOutputModel>().FirstOrDefault();

            var groupTrainingT = AutoMapperConfig.MapperInstance.Map<T>(groupTraining);

            return groupTrainingT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var groupTrainings = this.groupTrainingsRepository.All().To<GroupTrainingServiceOutputModel>();

            var groupTrainingsT = groupTrainings.To<T>().ToList();

            return groupTrainingsT;
        }
    }
}
