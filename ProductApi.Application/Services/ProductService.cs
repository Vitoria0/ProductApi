using ProductApi.Application.DTOs;
using ProductApi.Application.Interfaces;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse> CreateAsync(
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Price,
            request.Stock);

        await _repository.AddAsync(
            product,
            cancellationToken);

        return MapToResponse(product);
    }

    public async Task<ProductResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        return product is null
            ? null
            : MapToResponse(product);
    }

    public async Task<IReadOnlyList<ProductResponse>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(
            cancellationToken);

        return products
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<bool> UpdateAsync(
        int id,
        CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (product is null)
            return false;

        product.Update(
            request.Name,
            request.Price,
            request.Stock);

        await _repository.UpdateAsync(
            product,
            cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (product is null)
            return false;

        await _repository.DeleteAsync(
            product,
            cancellationToken);

        return true;
    }

    private static ProductResponse MapToResponse(
        Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}