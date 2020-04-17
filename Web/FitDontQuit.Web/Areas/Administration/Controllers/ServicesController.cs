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

        public IActionResult Index()
        {
            var services = this.servicesService.GettAll<ServiceViewModel>();

            return this.View(services);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var serviceServiceModel = AutoMapperConfig.MapperInstance.Map<CreateServiceInputModel>(inputModel);
            await this.servicesService.CreateAsync(serviceServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var service = this.servicesService.GetById<EditServiceModel>(id);

            if (service == null)
            {
                return this.NotFound();
            }

            return this.View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditServiceModel serviceModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(serviceModel);
            }

            var serviceServiceModel = AutoMapperConfig.MapperInstance.Map<EditServiceServiceModel>(serviceModel);
            await this.servicesService.EditAsync(id, serviceServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var serviceModel = this.servicesService.GetById<DeleteServiceModel>(id);

            if (serviceModel == null)
            {
                return this.NotFound();
            }

            return this.View(serviceModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteServiceModel serviceModel)
        {
            await this.servicesService.DeleteAsync(serviceModel.Id);

            return this.RedirectToAction("Index");
        }
    }
}
