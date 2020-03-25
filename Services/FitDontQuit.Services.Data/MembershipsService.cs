namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Common.Repositories;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    public class MembershipsService : IMembershipsService
    {
        private readonly IDeletableEntityRepository<Membership> membershipRepository;

        public MembershipsService(IDeletableEntityRepository<Membership> membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }

        public async Task CreateAsync(MembershipServiceModel membershipModel)
        {
            var membership = new Membership
            {
                Name = membershipModel.Name,
                Price = membershipModel.Price,
                Duration = membershipModel.Duration,
            };

            await this.membershipRepository.AddAsync(membership);
            await this.membershipRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var membership = this.membershipRepository.All().FirstOrDefault(m => m.Id == id);

            this.membershipRepository.Delete(membership);
            await this.membershipRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, MembershipServiceModel membershipModel)
        {
            var membership = this.membershipRepository.All().Where(m => m.Id == id).FirstOrDefault();

            membership.Name = membershipModel.Name;
            membership.Price = membershipModel.Price;
            membership.Duration = membershipModel.Duration;

            await this.membershipRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            return this.membershipRepository.All().Where(m => m.Id == id).To<T>().FirstOrDefault();
        }

        public IEnumerable<T> GettAll<T>()
        {
            var memberships = this.membershipRepository.All().To<T>().ToList();

            return memberships;
        }
    }
}
