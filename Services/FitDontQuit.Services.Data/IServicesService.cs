namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Services;

    public interface IServicesService
    {
        Task CreateAsync(ServiceServiceInputModel serviceModel);

        Task EditAsync(int id, ServiceServiceInputModel serviceModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task<bool> DeleteAsync(int id);
    }
}
