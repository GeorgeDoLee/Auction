using Auction.Domain.Entities;
using Auction.Domain.Exceptions;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class SportService : ISportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<SportService> _logger;

    public SportService(IUnitOfWork unitOfWork, ILogger<SportService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<Sport>> GetAllSports()
    {
        _logger.LogInformation("getting all the sports.");

        var sports = await _unitOfWork.Sports.GetAllAsync();

        return sports;
    }

    public async Task<Sport> GetSportById(int id)
    {
        _logger.LogInformation("getting sport by id: {SportId}", id);

        var sport = await _unitOfWork.Sports.GetAsync(id)
            ?? throw new NotFoundException(nameof(Sport), id.ToString());

        return sport;
    }

    public async Task DeleteSport(int id)
    {
        _logger.LogInformation("deleting sport with id: {SportId}", id);

        var sport = await _unitOfWork.Sports.GetAsync(id)
            ?? throw new NotFoundException(nameof(Sport), id.ToString());

        await _unitOfWork.Sports.RemoveAsync(sport);
    }
}
