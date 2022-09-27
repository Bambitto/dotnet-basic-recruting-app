using MatchDataManager.Api.Data;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;
    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Team team)
    {
        _context.Teams.Remove(team);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        var teams = await _context.Teams.ToListAsync();
        return teams;
    }

    public async Task<Team> GetAsync(Guid id)
    {
        var team = await _context.Teams.FindAsync(id);
        return team;
    }

    public bool NameValidation(string name)
    {
        return _context.Teams.Any(x => x.Name == name);
    }

    public async Task<bool> Update(Team team, Team teamToUpdate)
    {
        teamToUpdate.Name = team.Name;
        teamToUpdate.CoachName = team.CoachName;
        return await _context.SaveChangesAsync() > 0;
    }
}