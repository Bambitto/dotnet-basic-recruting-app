using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Services
{
    public interface ITeamService
    {
        Task<bool> CreateAsync(Team team);
        Task<bool> Update(Team team);
        Task<bool> Delete(Guid id);
        Task<Team> GetAsync(Guid id);
        Task<IEnumerable<Team>> GetAllAsync();
    }
}
