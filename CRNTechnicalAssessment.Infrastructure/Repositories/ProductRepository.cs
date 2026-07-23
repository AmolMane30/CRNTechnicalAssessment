using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Domain.Entities;
using CRNTechnicalAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRNTechnicalAssessment.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<Product?> GetByNameAsync(string productName)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.ProductName == productName);
    }
}