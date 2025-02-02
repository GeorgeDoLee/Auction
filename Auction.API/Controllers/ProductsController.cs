//using Auction.Application.Services;
//using Auction.Domain.Constants;
//using Auction.Domain.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Auction.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ProductsController : ControllerBase
//{
//    private readonly IProductService _productService;

//    public ProductsController(IProductService productService)
//    {
//        _productService = productService;
//    }

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
//    {
//        var products = await _productService.GetAllProducts();

//        return Ok(products);
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<Product>> GetById([FromRoute]int id)
//    {
//        var product = await _productService.GetProductById(id);

//        return Ok(product);
//    }

//    [HttpDelete("{id}")]
//    [Authorize(Roles = UserRoles.Admin)]
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<IActionResult> DeleteProduct([FromRoute]int id)
//    {
//        await _productService.DeleteProduct(id);

//        return NoContent();
//    }
//}
