using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Application.Interfaces.Services;
using CRNTechnicalAssessment.Application.DTOs.Product;
using CRNTechnicalAssessment.Domain.Entities;
namespace CRNTechnicalAssessment.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(product => new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName
        });
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            return null;
        }

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName
        };
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
    {
        var existingProduct = await _productRepository.GetByNameAsync(createProductDto.ProductName);

        if (existingProduct != null)
        {
            throw new Exception("A product with the same name already exists.");
        }

        var product = new Product
        {
            ProductName = createProductDto.ProductName,
            CreatedBy = "System",
            CreatedOn = DateTime.UtcNow
        };

        await _productRepository.AddAsync(product);

        await _productRepository.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName
        };
    }

    public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto updateProductDto)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            return null;
        }

        product.ProductName = updateProductDto.ProductName;
        product.ModifiedBy = "System";
        product.ModifiedOn = DateTime.UtcNow;

        _productRepository.Update(product);

        await _productRepository.SaveChangesAsync();

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            return false;
        }

        _productRepository.Delete(product);

        await _productRepository.SaveChangesAsync();

        return true;
    }
}