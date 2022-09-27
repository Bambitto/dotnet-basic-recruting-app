using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories
{
    public interface ILocationRepository
    {
        Task<bool> CreateAsync(Location location);
        Task<bool> Update(Location location, Location locationToUpdate);
        Task<bool> Delete(Location location);
        Task<Location> GetAsync(Guid id);
        Task<IEnumerable<Location>> GetAllAsync();
        bool NameValidation(string name);
    }
}
