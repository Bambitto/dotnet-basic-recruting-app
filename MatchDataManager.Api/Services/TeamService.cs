using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Team team)
        {
            var existingTeam = _repository.GetAsync(team.Id);
            if (existingTeam is not null)
            {
                throw new BadRequestException($"Team with id {team.Id} already exists");
            }
            return await _repository.CreateAsync(team);
        }

        public async Task<bool> Delete(Guid id)
        {
            var team = await _repository.GetAsync(id);
            if (team is null)
            {
                throw new NotFoundException("Team not found");
            }
            var result = await _repository.Delete(team);
            return result;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            var teams = await _repository.GetAllAsync();
            return teams;
        }

        public async Task<Team> GetAsync(Guid id)
        {
            var team = await _repository.GetAsync(id);
            return team;
        }

        public async Task<bool> Update(Team team)
        {
            var teamToUpdate = await _repository.GetAsync(team.Id);
            if (teamToUpdate is null)
            {
                throw new NotFoundException($"Team with id {team.Id} not found");
            }
            var result = await _repository.Update(team, teamToUpdate);
            return result;
        }
    }
}
