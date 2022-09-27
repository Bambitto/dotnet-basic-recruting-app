using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories
{
    public interface ITeamRepository
    {
        Task<bool> CreateAsync(Team team);
        Task<bool> Update(Team team, Team teamToUpdate);
        Task<bool> Delete(Team team);
        Task<Team> GetAsync(Guid id);
        Task<IEnumerable<Team>> GetAllAsync();
        bool NameValidation(string name);
    }
}
