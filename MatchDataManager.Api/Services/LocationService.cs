using FluentValidation;
using FluentValidation.Results;
using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace MatchDataManager.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Location location)
        {
            var existingLocation = _repository.GetAsync(location.Id);
            if (existingLocation is not null)
            {
                throw new BadRequestException($"Location with id {location.Id} already exists");
            }
            return await _repository.CreateAsync(location);
        }

        public async Task<bool> Delete(Guid id)
        {
            var location = await _repository.GetAsync(id);
            if (location is null)
            {
                throw new NotFoundException("Location not found");
            }
            var result = await _repository.Delete(location);
            return result;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            var locations = await _repository.GetAllAsync();
            return locations;
        }

        public async Task<Location> GetAsync(Guid id)
        {
            var location = await _repository.GetAsync(id);
            return location;
        }

        public async Task<bool> Update(Location location)
        {
            var locationToUpdate = await _repository.GetAsync(location.Id);
            if (locationToUpdate is null)
            {
                throw new NotFoundException($"Location with id {location.Id} not found");
            }
            var result = await _repository.Update(location, locationToUpdate);
            return result;
        }
    }
}
