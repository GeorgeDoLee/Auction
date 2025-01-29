using Auction.Application.Dtos;

namespace Auction.Application.Services;

public interface IUserService
{
    Task AssignUserRole(AssignUserRoleDto assignUserRoleDto);
    Task UnassignUserRole(UnassignUserRoleDto unassignUserRoleDto);
}