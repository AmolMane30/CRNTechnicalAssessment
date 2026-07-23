using CRNTechnicalAssessment.Application.DTOs.Item;

namespace CRNTechnicalAssessment.Application.Interfaces.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetAllAsync();

    Task<ItemDto?> GetByIdAsync(int id);

    Task<ItemDto> CreateAsync(CreateItemDto createItemDto);

    Task<ItemDto?> UpdateAsync(int id, UpdateItemDto updateItemDto);

    Task<bool> DeleteAsync(int id);
}