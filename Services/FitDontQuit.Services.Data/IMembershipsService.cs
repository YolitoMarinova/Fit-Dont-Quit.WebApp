namespace FitDontQuit.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FitDontQuit.Services.Models.Memberships;

    public interface IMembershipsService
    {
        Task CreateAsync(CreateMembershipInputModel membershipModel);

        Task EditAsync(int id, EditMembershipInputModel membershipModel);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        IEnumerable<T> GetByNames<T>(string[] names);

        Task DeleteAsync(int id);
    }
}
