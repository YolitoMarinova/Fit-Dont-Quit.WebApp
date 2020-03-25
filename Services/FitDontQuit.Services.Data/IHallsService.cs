namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Halls;

    public interface IHallsService
    {
        Task CreateAsync(HallServiceModel hallModel);

        Task EditAsync(int id, HallServiceModel hallModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
