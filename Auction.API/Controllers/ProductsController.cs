using Auction.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productService.GetAllProducts();
        return Ok(products);
    }
}
