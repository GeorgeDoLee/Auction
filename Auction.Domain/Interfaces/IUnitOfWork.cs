using Auction.Domain.Entities;

namespace Auction.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        Task Complete();
    }
}
