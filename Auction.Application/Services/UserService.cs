using Auction.Application.Dtos;
using Auction.Domain.Entities;
using Auction.Domain.Exceptions;
using Auction.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(ILogger<UserService> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AssignUserRole(AssignUserRoleDto assignUserRoleDto)
    {
        _logger.LogInformation("Assigning user role: {@AssignUserRoleDto}", assignUserRoleDto);

        var user = await _userManager.FindByEmailAsync(assignUserRoleDto.UserEmail)
            ?? throw new NotFoundException(nameof(User), assignUserRoleDto.UserEmail);

        var role = await _roleManager.FindByNameAsync(assignUserRoleDto.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), assignUserRoleDto.RoleName);

        await _userManager.AddToRoleAsync(user, role.Name!);
    }

    public async Task UnassignUserRole(UnassignUserRoleDto unassignUserRoleDto)
    {
        _logger.LogInformation("Unassigning user role: {@UnassignUserRoleDto}", unassignUserRoleDto);

        var user = await _userManager.FindByEmailAsync(unassignUserRoleDto.UserEmail)
            ?? throw new NotFoundException(nameof(User), unassignUserRoleDto.UserEmail);

        var role = await _roleManager.FindByNameAsync(unassignUserRoleDto.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), unassignUserRoleDto.RoleName);

        await _userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
