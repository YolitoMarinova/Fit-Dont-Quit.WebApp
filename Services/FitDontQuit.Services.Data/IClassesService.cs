namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Classes;

    public interface IClassesService
    {
        Task CreateAsync(CreateClassServiceModel classModel);

        Task EditAsync(int id, EditClassServiceModel classModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
