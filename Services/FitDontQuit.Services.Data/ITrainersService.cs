namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Professions;
    using FitDontQuit.Services.Models.Trainers;

    public interface ITrainersService
    {
        Task CreateAsync(TrainerServiceModel trainerModel);

        Task EditAsync(int id, TrainerServiceModel trainerModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
