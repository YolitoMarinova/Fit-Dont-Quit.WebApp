﻿namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Halls;

    public interface IHallsService
    {
        Task CreateAsync(CreateHallServiceModel hallModel);

        Task EditAsync(int id, EditHallServiceModel hallModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
