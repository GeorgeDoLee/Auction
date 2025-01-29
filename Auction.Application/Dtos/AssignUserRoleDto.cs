namespace Auction.Application.Dtos;

public class AssignUserRoleDto
{
    public required string UserEmail { get; set; }
    public required string RoleName { get; set; }
}
