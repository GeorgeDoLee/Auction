using Auction.Domain.Entities;

namespace Auction.Application.Services;

public interface ILeagueService
{
    Task DeleteLeague(int id);
    Task<IEnumerable<League>> GetAllLeagues();
    Task<League> GetLeagueById(int id);
}