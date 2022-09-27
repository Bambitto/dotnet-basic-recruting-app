using MatchDataManager.Api.Data;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext _context;
    public LocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Location location)
    {
        await _context.Locations.AddAsync(location);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Location location)
    {
        _context.Locations.Remove(location);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations;
    }

    public async Task<Location> GetAsync(Guid id)
    {
        var location = await _context.Locations.FindAsync(id);
        return location;
    }

    public bool NameValidation(string name)
    {
        return  _context.Locations.Any(x => x.Name == name);
    }

    public async Task<bool> Update(Location location, Location locationToUpdate)
    {
        locationToUpdate.Name = location.Name;
        locationToUpdate.City = location.City;
        return await _context.SaveChangesAsync() > 0;
    }
}