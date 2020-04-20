namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;

    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task CreateAsync(CreateArticleServiceModel articleModel)
        {
            var article = new Article
            {
                Title = articleModel.Title,
                Content = articleModel.Content,
                User = articleModel.User,
                ImageUrl = articleModel.ImageUrl,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditArticleServiceModel articleModel)
        {
            var article = this.articlesRepository.All().Where(a => a.Id == id).FirstOrDefault();

            article.Title = articleModel.Title;
            article.Content = articleModel.Content;

            await this.articlesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = this.articlesRepository.All().FirstOrDefault(a => a.Id == id);

            this.articlesRepository.Delete(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var article = this.articlesRepository.All().Where(a => a.Id == id).To<ArticleServiceOutputModel>().FirstOrDefault();

            var articleT = AutoMapperConfig.MapperInstance.Map<T>(article);

            return articleT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var articles = this.articlesRepository.All().To<ArticleServiceOutputModel>();

            var articlesT = articles.To<T>().ToList();

            return articlesT;
        }

        public IEnumerable<T> GettThreeLatest<T>()
        {
            var articles = this.articlesRepository.All().OrderByDescending(x => x.CreatedOn).Take(3).To<ArticleServiceOutputModel>();

            var articlesT = articles.To<T>().ToList();

            return articlesT;
        }
    }
}
