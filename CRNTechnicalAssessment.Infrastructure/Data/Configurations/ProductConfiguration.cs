using CRNTechnicalAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRNTechnicalAssessment.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.CreatedBy)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.CreatedOn)
               .IsRequired();

        builder.Property(p => p.ModifiedBy)
               .HasMaxLength(100);

        builder.Property(p => p.ModifiedOn);
    }
}