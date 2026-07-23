using CRNTechnicalAssessment.Application.DTOs.Product;

namespace CRNTechnicalAssessment.Application.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<ProductDto> CreateAsync(CreateProductDto createProductDto);

    Task<ProductDto?> UpdateAsync(int id, UpdateProductDto updateProductDto);

    Task<bool> DeleteAsync(int id);
}