using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitDontQuit.Data.Common.Repositories;
using FitDontQuit.Data.Models;
using FitDontQuit.Services.Models.PurchasedMemberships;
using FitDontQuit.Services.Mapping;

namespace FitDontQuit.Services.Data
{
    public class PurchasedMembershipsService : IPurchasedMembershipsService
    {
        private readonly IDeletableEntityRepository<PurchasedMembership> purchasedMembershipRepository;

        public PurchasedMembershipsService(IDeletableEntityRepository<PurchasedMembership> purchasedMembershipRepository)
        {
            this.purchasedMembershipRepository = purchasedMembershipRepository;
        }

        public async Task CreateAsync(PurchasedMembershipInputServiceModel purchasedMembershipModel)
        {
            var purchasedMembership = new PurchasedMembership
            {
                UserId = purchasedMembershipModel.UserId,
                MembershipId = purchasedMembershipModel.MembershipId,
                StartDate = purchasedMembershipModel.StartDate,
                EndDate = purchasedMembershipModel.EndDate,
            };

            await this.purchasedMembershipRepository.AddAsync(purchasedMembership);
            await this.purchasedMembershipRepository.SaveChangesAsync();
        }

        public PurchaseUserViewModel GetByUser(ApplicationUser user)
        {
            return this.purchasedMembershipRepository.All().Where(x => x.UserId == user.Id).To<PurchaseUserViewModel>().FirstOrDefault();
        }
    }
}
