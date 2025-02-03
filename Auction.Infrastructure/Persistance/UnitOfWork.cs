using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistance;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public IProductRepository Products { get; }

    public UnitOfWork(AuctionDbContext context)
    {
        _context = context;

        Products = new ProductRepository(context);
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}