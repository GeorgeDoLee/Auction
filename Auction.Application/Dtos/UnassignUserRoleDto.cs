namespace Auction.Application.Dtos;

public class UnassignUserRoleDto
{
    public required string UserEmail { get; set; }
    public required string RoleName { get; set; }
}
