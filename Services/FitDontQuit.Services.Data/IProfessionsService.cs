namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Professions;

    public interface IProfessionsService
    {
        Task CreateAsync(ProfessionServiceInputModel professionModel);

        Task EditAsync(int id, ProfessionServiceInputModel professionModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
