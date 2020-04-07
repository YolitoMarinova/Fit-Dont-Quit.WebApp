using FitDontQuit.Services.Data;
using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Professions;
using FitDontQuit.Web.ViewModels.Administration.Professions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    public class ProfessionsController : AdministrationController
    {
        private readonly IProfessionsService professionsService;

        public ProfessionsController(IProfessionsService professionsService)
        {
            this.professionsService = professionsService;
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

            var professionServiceModel = AutoMapperConfig.MapperInstance.Map<ProfessionServiceModel>(inputModel);
            await this.professionsService.CreateAsync(professionServiceModel);

            return this.RedirectToAction("All");
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

            var professionServiceModel = AutoMapperConfig.MapperInstance.Map<ProfessionServiceModel>(professionModel);
            await this.professionsService.EditAsync(id, professionServiceModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var profession = this.professionsService.GetById<ProfessionInputModel>(id);

            if (profession == null)
            {
                return this.NotFound();
            }

            await this.professionsService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var professions = this.professionsService.GettAll<ProfessionViewModel>();

            return this.View(professions);
        }
    }
}
