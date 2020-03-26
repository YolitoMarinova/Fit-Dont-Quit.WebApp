namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Services;

    public interface IServicesService
    {
        Task CreateAsync(ServiceServiceModel serviceModel);

        Task EditAsync(int id, ServiceServiceModel serviceModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
