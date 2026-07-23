using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetByNameAsync(string productName);
}