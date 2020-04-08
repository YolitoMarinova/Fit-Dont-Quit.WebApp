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

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<HallServiceInputModel>(inputModel);
            await this.hallsService.CreateAsync(hallServiceModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var hall = this.hallsService.GetById<HallInputModel>(id);

            if (hall == null)
            {
                return this.BadRequest();
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

            var hallServiceModel = AutoMapperConfig.MapperInstance.Map<HallServiceInputModel>(hallModel);
            await this.hallsService.EditAsync(id, hallServiceModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.hallsService.DeleteAsync(id);

            if (result != true)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var halls = this.hallsService.GettAll<HallViewModel>();

            return this.View(halls);
        }
    }
}
