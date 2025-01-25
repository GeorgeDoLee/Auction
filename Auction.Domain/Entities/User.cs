using Auction.Domain.Enums;

namespace Auction.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public UserRole UserRole { get; set; }
}
