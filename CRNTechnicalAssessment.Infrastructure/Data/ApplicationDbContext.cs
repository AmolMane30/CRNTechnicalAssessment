using CRNTechnicalAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRNTechnicalAssessment.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Item> Items => Set<Item>();
}