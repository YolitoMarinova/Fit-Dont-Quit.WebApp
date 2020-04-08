namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.GroupTrainings;

    public interface IGroupTrainingsService
    {
        Task CreateAsync(GroupTrainingServiceInputModel groupTrainingModel);

        Task EditAsync(int id, GroupTrainingServiceInputModel groupTrainingModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task<bool> DeleteAsync(int id);
    }
}
