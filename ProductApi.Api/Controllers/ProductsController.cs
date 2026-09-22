using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.DTOs;
using ProductApi.Application.Services;

namespace ProductApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var products = await _service.GetAllAsync(
            cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var product = await _service.GetByIdAsync(
            id,
            cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _service.CreateAsync(
            request,
            cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var updated = await _service.UpdateAsync(
            id,
            request,
            cancellationToken);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(
            id,
            cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}