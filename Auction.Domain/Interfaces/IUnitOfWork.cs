namespace Auction.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ISportRepository Sports { get; }
    ILeagueRepository Leagues { get; }

    Task Complete();
}
