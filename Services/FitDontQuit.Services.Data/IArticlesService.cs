﻿namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleServiceModel articleModel);

        Task EditAsync(int id, EditArticleServiceModel articleModel);

        IEnumerable<T> GettAll<T>();

        IEnumerable<T> GettThreeLatest<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
