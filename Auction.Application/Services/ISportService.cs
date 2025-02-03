using Auction.Domain.Entities;

namespace Auction.Application.Services;

public interface ISportService
{
    Task DeleteSport(int id);
    Task<IEnumerable<Sport>> GetAllSports();
    Task<Sport> GetSportById(int id);
}