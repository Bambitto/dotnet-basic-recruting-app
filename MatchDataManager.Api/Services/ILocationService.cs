using MatchDataManager.Api.Models;
namespace MatchDataManager.Api.Services
{
    public interface ILocationService
    {
        Task<bool> CreateAsync(Location location);
        Task<bool> Update(Location location);
        Task<bool> Delete(Guid id);
        Task<Location> GetAsync(Guid id);
        Task<IEnumerable<Location>> GetAllAsync();
    }
}
