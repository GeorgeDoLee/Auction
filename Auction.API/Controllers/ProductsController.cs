﻿using Auction.Application.Dtos;
using Auction.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var product = await _productService.GetProductById(id);

        if(product == null)
        {
            return NotFound($"Product with id: {id} was not found.");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        var id = await _productService.CreateProduct(createProductDto);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute]int id, UpdateProductDto updateProductDto)
    {
        var productUpdated = await _productService.UpdateProduct(id, updateProductDto);

        return productUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute]int id)
    {
        var productDeleted = await _productService.DeleteProduct(id);
        
        return productDeleted ? NoContent() : NotFound();
    }
}
