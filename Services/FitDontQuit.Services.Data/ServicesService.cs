﻿namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Services;

    public class ServicesService : IServicesService
    {
        private readonly IDeletableEntityRepository<Service> servicesRepository;

        public ServicesService(IDeletableEntityRepository<Service> servicesRepository)
        {
            this.servicesRepository = servicesRepository;
        }

        public async Task CreateAsync(ServiceServiceInputModel serviceModel)
        {
            var service = new Service
            {
                Name = serviceModel.Name,
                Price = serviceModel.Price,
            };

            await this.servicesRepository.AddAsync(service);
            await this.servicesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, ServiceServiceInputModel serviceModel)
        {
            var service = this.servicesRepository.All().Where(s => s.Id == id).FirstOrDefault();

            service.Name = serviceModel.Name;
            service.Price = serviceModel.Price;

            await this.servicesRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var service = this.servicesRepository.All().FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return false;
            }

            this.servicesRepository.Delete(service);
            await this.servicesRepository.SaveChangesAsync();

            return true;
        }

        public T GetById<T>(int id)
        {
            var service = this.servicesRepository.All().Where(s => s.Id == id).To<ServiceServiceOutputModel>().FirstOrDefault();

            var serviceT = AutoMapperConfig.MapperInstance.Map<T>(service);

            return serviceT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var services = this.servicesRepository.All().To<ServiceServiceOutputModel>();

            var servicesT = services.To<T>().ToList();

            return servicesT;
        }
    }
}
