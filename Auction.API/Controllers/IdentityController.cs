using Auction.Application.Dtos;
using Auction.Application.Services;
using Auction.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IUserService _userService;
    public IdentityController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleDto assignUserRoleDto)
    {
        await _userService.AssignUserRole(assignUserRoleDto);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnassignUserRole(UnassignUserRoleDto unassignUserRoleDto)
    { 
        await _userService.UnassignUserRole(unassignUserRoleDto);
        return NoContent();
    }
}
