using DiscountCampaignsBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCampaignsBackend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private static readonly Product[] Products = new Product[]
    {
        new Product { Name = "T-Shirt" , Category = "Clothing" , Price = 500 },
        new Product { Name = "Hoodie" , Category = "Clothing" , Price = 750 },
        new Product { Name = "Laptop" , Category = "Electronics" , Price = 5000 },
        new Product { Name = "Smart Phone" , Category = "Electronics" , Price = 3500 },
        new Product { Name = "Watch" , Category = "Accessories" , Price = 2500 },
        new Product { Name = "Earring" , Category = "Accessories" , Price = 1500 },
    };
    private readonly ILogger<ProductsController> _logger;
    private readonly DiscountCalculator _discountCalculator;

    public ProductsController(ILogger<ProductsController> logger, DiscountCalculator discountCalculator)
    {
        _logger = logger;
        _discountCalculator = discountCalculator;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return Products;
    }

    [HttpPost]
    public IActionResult CalculateTotalSum(DiscountRequestDto discountRequestDto)
    {
        var total = _discountCalculator.CalculateTotal(discountRequestDto);
        return Ok(total);
    }
}
