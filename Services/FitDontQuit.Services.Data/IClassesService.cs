using FitDontQuit.Services.Models.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitDontQuit.Services.Data
{
    public interface IClassesService
    {
        Task CreateAsync(CreateClassServiceModel classModel);

        Task EditAsync(int id, EditClassServiceModel classModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
