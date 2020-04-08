namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Services;
    using FitDontQuit.Web.ViewModels.Administration.Services;

    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var serviceServiceModel = AutoMapperConfig.MapperInstance.Map<ServiceServiceInputModel>(inputModel);
            await this.servicesService.CreateAsync(serviceServiceModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var service = this.servicesService.GetById<ServiceInputModel>(id);

            if (service == null)
            {
                return this.NotFound();
            }

            return this.View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServiceInputModel serviceModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(serviceModel);
            }

            var serviceServiceModel = AutoMapperConfig.MapperInstance.Map<ServiceServiceInputModel>(serviceModel);
            await this.servicesService.EditAsync(id, serviceServiceModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = this.servicesService.GetById<ServiceInputModel>(id);

            if (service == null)
            {
                return this.NotFound();
            }

            await this.servicesService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var services = this.servicesService.GettAll<ServiceViewModel>();

            return this.View(services);
        }
    }
}
