namespace FitDontQuit.Web.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;
    using FitDontQuit.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(IArticlesService articlesService, ICloudinaryService cloudinaryService, UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.cloudinaryService = cloudinaryService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var articles = this.articlesService.GettAll<ArticleInListViewModel>();

            return this.View(articles);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleModel articleModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(articleModel);
            }

            articleModel.ImageUrl = await this.cloudinaryService.UploadAsync(articleModel.Image, articleModel.Image.FileName);

            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.BadRequest();
            }

            articleModel.User = user;

            var serviceModel = AutoMapperConfig.MapperInstance.Map<CreateArticleServiceModel>(articleModel);

            await this.articlesService.CreateAsync(serviceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var article = this.articlesService.GetById<EditArticleModel>(id);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditArticleModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (inputModel.Image != null)
            {
                inputModel.ImageUrl = await this.cloudinaryService.UploadAsync(inputModel.Image, inputModel.Image.FileName);
            }

            var articleServiceModel = AutoMapperConfig.MapperInstance.Map<EditArticleServiceModel>(inputModel);

            await this.articlesService.EditAsync(id, articleServiceModel);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        public IActionResult Delete(int id)
        {
            var articleModel = this.articlesService.GetById<DeleteArticleModel>(id);

            if (articleModel == null)
            {
                return this.NotFound();
            }

            return this.View(articleModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteArticleModel articleModel)
        {
            await this.articlesService.DeleteAsync(articleModel.Id);

            return this.RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var articleModel = this.articlesService.GetById<ArticleDetailsViewModel>(id);

            if (articleModel == null)
            {
                return this.NotFound();
            }

            return this.View(articleModel);
        }
    }
}
