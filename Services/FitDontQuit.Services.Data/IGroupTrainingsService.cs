namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.GroupTrainings;

    public interface IGroupTrainingsService
    {
        Task CreateAsync(CreateGroupTrainingServiceModel groupTrainingModel);

        Task EditAsync(int id, EditGroupTrainingServiceModel groupTrainingModel);

        Task DeleteAsync(int id);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);
    }
}
