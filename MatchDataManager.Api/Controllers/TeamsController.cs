using FluentValidation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;
    private readonly IValidator<Team> _validator;
    public TeamsController(ITeamService teamService, IValidator<Team> validator)
    {
        _teamService = teamService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> AddTeam(Team team)
    {
        var result = await _validator.ValidateAsync(team);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }
        if (await _teamService.CreateAsync(team))
        {
            return Ok();
        }
        return BadRequest("Something went wrong");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTeam(Guid teamId)
    {
        await _teamService.Delete(teamId);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _teamService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var team = await _teamService.GetAsync(id);
        if (team is null)
        {
            return NotFound();
        }

        return Ok(team);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTeam(Team team)
    {
        var result = await _validator.ValidateAsync(team);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }
        await _teamService.Update(team);
        return Ok();
    }
}