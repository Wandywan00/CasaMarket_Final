using CasaMarket.Application.Dtos;
using CasaMarket.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CasaMarket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _svc;
    public ProductsController(ProductService svc) => _svc = svc;

    // GET /api/products?q=&category=&sort=priceAsc|priceDesc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(
        [FromQuery] string? q,
        [FromQuery] string? category,
        [FromQuery] string? sort)
    {
        var items = await _svc.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(q))
            items = items.Where(p =>
                    (p.Name?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.Description?.Contains(q, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

        if (!string.IsNullOrWhiteSpace(category))
            items = items.Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase)).ToList();

        items = sort switch
        {
            "priceAsc" => items.OrderBy(p => p.Price).ToList(),
            "priceDesc" => items.OrderByDescending(p => p.Price).ToList(),
            _ => items
        };

        return Ok(items);
    }

    // GET /api/products/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var dto = (await _svc.GetAllAsync()).FirstOrDefault(p => p.ProductID == id);
        if (dto is null) return NotFound();
        return Ok(dto);
    }
}
