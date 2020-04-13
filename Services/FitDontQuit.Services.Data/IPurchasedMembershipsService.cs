using FitDontQuit.Services.Models.PurchasedMemberships;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitDontQuit.Services.Data
{
    public interface IPurchasedMembershipsService
    {
        Task CreateAsync(PurchasedMembershipInputServiceModel purchasedMembershipModel);
    }
}
