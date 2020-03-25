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

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HallInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<HallServiceModel>(inputModel);
            await this.hallsService.CreateAsync(hallServiceModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var hall = this.hallsService.GetById<HallInputModel>(id);

            if (hall == null)
            {
                return this.NotFound();
            }

            return this.View(hall);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HallInputModel hallModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(hallModel);
            }

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<HallServiceModel>(hallModel);
            await this.hallsService.EditAsync(id, hallServiceModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var hall = this.hallsService.GetById<HallInputModel>(id);

            if (hall == null)
            {
                return this.NotFound();
            }

            await this.hallsService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var halls = this.hallsService.GettAll<HallViewModel>();

            return this.View(halls);
        }
    }
}
