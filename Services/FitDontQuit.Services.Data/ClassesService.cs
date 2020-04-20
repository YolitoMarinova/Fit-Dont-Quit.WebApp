namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Classes;

    public class ClassesService : IClassesService
    {
        private readonly IDeletableEntityRepository<Class> classRepository;

        public ClassesService(IDeletableEntityRepository<Class> classRepository)
        {
            this.classRepository = classRepository;
        }

        public async Task CreateAsync(CreateClassServiceModel classModel)
        {
            var @class = new Class
            {
                StartHour = classModel.StartHour,
                EndHour = classModel.EndHour,
                Capacity = classModel.Capacity,
                DayOfWeek = classModel.DayOfWeek,
                GroupTrainingId = classModel.GroupTrainingId,
                TrainerId = classModel.TrainerId,
            };

            await this.classRepository.AddAsync(@class);
            await this.classRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, EditClassServiceModel classModel)
        {
            var @class = this.classRepository.All().Where(c => c.Id == id).FirstOrDefault();

            @class.StartHour = classModel.StartHour;
            @class.EndHour = classModel.EndHour;
            @class.Capacity = classModel.Capacity;
            @class.DayOfWeek = classModel.DayOfWeek;
            @class.GroupTrainingId = classModel.GroupTrainingId;
            @class.TrainerId = classModel.TrainerId;

            await this.classRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var @class = this.classRepository.All().FirstOrDefault(c => c.Id == id);

            this.classRepository.Delete(@class);
            await this.classRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var @class = this.classRepository.All().Where(a => a.Id == id).To<ClassServiceOutputModel>().FirstOrDefault();

            var classT = AutoMapperConfig.MapperInstance.Map<T>(@class);

            return classT;
        }

        public IEnumerable<T> GettAll<T>()
        {
            var classes = this.classRepository.All().To<ClassServiceOutputModel>();

            var classesT = classes.To<T>().ToList();

            return classesT;
        }
    }
}
