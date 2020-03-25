namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Memberships;

    public interface IMembershipsService
    {
        Task CreateAsync(MembershipServiceModel membershipModel);

        Task EditAsync(int id, MembershipServiceModel membershipModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
