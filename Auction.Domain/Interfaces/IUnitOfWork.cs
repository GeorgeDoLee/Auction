using Auction.Domain.Entities;

namespace Auction.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        Task Complete();
    }
}
