namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;
    using FitDontQuit.Web.ViewModels.Administration.Professions;
    using Microsoft.AspNetCore.Mvc;

    public class ProfessionsController : AdministrationController
    {
        private readonly IProfessionsService professionsService;

        public ProfessionsController(IProfessionsService professionsService)
        {
            this.professionsService = professionsService;
        }

        public IActionResult Index()
        {
            var professions = this.professionsService.GetAll<ProfessionViewModel>();

            return this.View(professions);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessionInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var professionServiceModel = AutoMapperConfig.MapperInstance.Map<ProfessionServiceInputModel>(inputModel);
            await this.professionsService.CreateAsync(professionServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var profession = this.professionsService.GetById<ProfessionInputModel>(id);

            if (profession == null)
            {
                return this.NotFound();
            }

            return this.View(profession);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProfessionInputModel professionModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(professionModel);
            }

            var professionServiceModel = AutoMapperConfig.MapperInstance.Map<ProfessionServiceInputModel>(professionModel);
            await this.professionsService.EditAsync(id, professionServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var professionModel = this.professionsService.GetById<DeleteProfessionModel>(id);

            if (professionModel == null)
            {
                return this.NotFound();
            }

            return this.View(professionModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProfessionModel professionModel)
        {
            await this.professionsService.DeleteAsync(professionModel.Id);

            return this.RedirectToAction("Index");
        }
    }
}
