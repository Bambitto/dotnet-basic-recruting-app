using FluentValidation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Api.Validation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        private readonly ILocationRepository _locationRepository;
        public TeamValidator(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            RuleFor(x => x.CoachName).MaximumLength(55);
            RuleFor(x => x.Name).Must(name => !_locationRepository.NameValidation(name))
                .WithMessage("This name already exists");
        }
    }
}
