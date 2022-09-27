using FluentValidation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IValidator<Location> _validator;
    public LocationsController(ILocationService locationService, IValidator<Location> validator)
    {
        _locationService = locationService;
        _validator = validator;
    }
    [HttpPost]
    public async Task<IActionResult> AddLocation(Location location)
    {
        var result = await _validator.ValidateAsync(location);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }
        if (await _locationService.CreateAsync(location))
        {
            return Ok();
        }
        return BadRequest("Something went wrong");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(Guid locationId)
    {
        await _locationService.Delete(locationId);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _locationService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var location = await _locationService.GetAsync(id);
        if (location is null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(Location location)
    {
        var result = await _validator.ValidateAsync(location);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }
        await _locationService.Update(location);
        return Ok();
    }
}