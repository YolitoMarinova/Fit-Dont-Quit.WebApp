namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Memberships;

    public interface IMembershipsService
    {
        Task CreateAsync(MembershipServiceInputModel membershipModel);

        Task EditAsync(int id, MembershipServiceInputModel membershipModel);

        IEnumerable<T> GettAll<T>();

        T GetById<T>(int id);

        Task<bool> DeleteAsync(int id);
    }
}
