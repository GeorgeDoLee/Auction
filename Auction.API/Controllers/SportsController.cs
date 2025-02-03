using Auction.Application.Services;
using Auction.Domain.Constants;
using Auction.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportsController : ControllerBase
{
    private readonly ISportService _sportService;

    public SportsController(ISportService sportService)
    {
        _sportService = sportService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sport>>> GetAll()
    {
        var sports = await _sportService.GetAllSports();

        return Ok(sports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sport>> GetById([FromRoute] int id)
    {
        var sport = await _sportService.GetSportById(id);

        return Ok(sport);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _sportService.DeleteSport(id);

        return NoContent();
    }
}
