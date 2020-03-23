namespace FitDontQuit.Services.Data
{
    using System.Threading.Tasks;

    public interface IHallsService
    {
        Task AddAsync(string hallModel);

        Task UpdateAsync(int id);
    }
}
