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

        public async Task CreateAsync(GroupTrainingServiceInputModel groupTrainingModel)
        {
            var groupTraining = new GroupTraining
            {
                Name = groupTrainingModel.Name,
                Description = groupTrainingModel.Description,
                DateTime = groupTrainingModel.DateTime,
                HallId = groupTrainingModel.HallId,
                TrainerId = groupTrainingModel.TrainerId,
            };

            await this.groupTrainingsRepository.AddAsync(groupTraining);
            await this.groupTrainingsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, GroupTrainingServiceInputModel groupTrainingModel)
        {
            var groupTraining = this.groupTrainingsRepository.All().Where(gt => gt.Id == id).FirstOrDefault();

            if (groupTraining.Name != groupTrainingModel.Name)
            {
                groupTraining.Name = groupTrainingModel.Name;
            }

            if (groupTraining.Description != groupTrainingModel.Description)
            {
                groupTraining.Description = groupTrainingModel.Description;
            }

            if (groupTraining.DateTime != groupTrainingModel.DateTime)
            {
                groupTraining.DateTime = groupTrainingModel.DateTime;
            }

            if (groupTraining.HallId != groupTrainingModel.HallId)
            {
                groupTraining.HallId = groupTrainingModel.HallId;
            }

            if (groupTraining.TrainerId != groupTrainingModel.TrainerId)
            {
                groupTraining.TrainerId = groupTrainingModel.TrainerId;
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
