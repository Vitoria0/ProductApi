using ProductApi.Domain.Entities;

namespace ProductApi.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Product product,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Product product,
        CancellationToken cancellationToken = default);
}