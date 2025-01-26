﻿using Auction.Domain.Entities;
using Auction.Domain.Interfaces;
using Auction.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly AuctionDbContext _context;

    public ProductRepository(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }
    
    public async Task<int> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}