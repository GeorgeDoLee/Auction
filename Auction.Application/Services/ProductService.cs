﻿using Auction.Domain.Entities;
using Auction.Domain.Exceptions;
using Auction.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Auction.Application.Services;

internal class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        _logger.LogInformation("getting all the products.");

        var products = await _productRepository.GetAllAsync();
        
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        _logger.LogInformation("getting product by id: {ProductId}", id);

        var product = await _productRepository.GetByIdAsync(id) 
            ?? throw new NotFoundException(nameof(Product), id.ToString());

        return product;
    }

    public async Task DeleteProduct(int id)
    {
        _logger.LogInformation("deleting product with id: {ProductId}", id);

        var product = await _productRepository.GetByIdAsync(id)
            ?? throw new NotFoundException(nameof(Product), id.ToString());

        await _productRepository.DeleteProduct(product);
    }
}
