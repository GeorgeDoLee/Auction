using Auction.Domain.Entities;
using Auction.Domain.Exceptions;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class LeagueService : ILeagueService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LeagueService> _logger;

    public LeagueService(IUnitOfWork unitOfWork, ILogger<LeagueService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<League>> GetAllLeagues()
    {
        _logger.LogInformation("getting all the leagues.");

        var leagues = await _unitOfWork.Leagues.GetAllAsync();

        return leagues;
    }

    public async Task<League> GetLeagueById(int id)
    {
        _logger.LogInformation("getting league by id: {LeagueId}", id);

        var league = await _unitOfWork.Leagues.GetAsync(id)
            ?? throw new NotFoundException(nameof(League), id.ToString());

        return league;
    }

    public async Task DeleteLeague(int id)
    {
        _logger.LogInformation("deleting league with id: {LeagueID}", id);

        var league = await _unitOfWork.Leagues.GetAsync(id)
            ?? throw new NotFoundException(nameof(League), id.ToString());

        await _unitOfWork.Leagues.RemoveAsync(league);
    }
}
