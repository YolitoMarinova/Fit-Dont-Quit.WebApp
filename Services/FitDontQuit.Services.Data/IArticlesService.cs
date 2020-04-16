namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Articles;

    public interface IArticlesService
    {
        Task CreateAsync(CreateArticleServiceModel articleModel);

        Task EditAsync(int id, ArticleServiceInputModel articleServiceModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
