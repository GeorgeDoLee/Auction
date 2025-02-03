using Auction.Application.Services;
using Auction.Domain.Constants;
using Auction.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaguesController : ControllerBase
{
    private readonly ILeagueService _leagueService;

    public LeaguesController(ILeagueService leagueService)
    {
        _leagueService = leagueService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<League>>> GetAll()
    {
        var sports = await _leagueService.GetAllLeagues();

        return Ok(sports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<League>> GetById([FromRoute] int id)
    {
        var sport = await _leagueService.GetLeagueById(id);

        return Ok(sport);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _leagueService.DeleteLeague(id);

        return NoContent();
    }
}
