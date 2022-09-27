using FluentValidation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Validation
{
    public class LocationValidator : AbstractValidator<Location>
    {
        private readonly ILocationRepository _locationRepository;
        public LocationValidator(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            RuleFor(x => x.City).NotEmpty().MaximumLength(55);
            RuleFor(x => x.Name).Must(name => !_locationRepository.NameValidation(name))
                .WithMessage("This name already exists");
        }
    }
}
