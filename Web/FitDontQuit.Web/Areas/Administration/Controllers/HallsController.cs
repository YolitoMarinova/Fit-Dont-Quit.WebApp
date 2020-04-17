namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;
    using FitDontQuit.Web.ViewModels.Administration.Halls;
    using Microsoft.AspNetCore.Mvc;

    public class HallsController : AdministrationController
    {
        private readonly IHallsService hallsService;

        public HallsController(IHallsService hallsService)
        {
            this.hallsService = hallsService;
        }

        public IActionResult Index()
        {
            var halls = this.hallsService.GettAll<HallViewModel>();

            return this.View(halls);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHallModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<CreateHallServiceModel>(inputModel);
            await this.hallsService.CreateAsync(hallServiceModel);

            return this.Redirect("Index");
        }

        public IActionResult Edit(int id)
        {
            var hall = this.hallsService.GetById<EditHallModel>(id);

            if (hall == null)
            {
                return this.BadRequest();
            }

            return this.View(hall);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHallModel hallModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(hallModel);
            }

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<EditHallServiceModel>(hallModel);
            await this.hallsService.EditAsync(id, hallServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var hallModel = this.hallsService.GetById<DeleteHallModel>(id);

            if (hallModel == null)
            {
                return this.NotFound();
            }

            return this.View(hallModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteHallModel hallModel)
        {
            await this.hallsService.DeleteAsync(hallModel.Id);

            return this.RedirectToAction("Index");
        }
    }
}
