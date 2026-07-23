using CRNTechnicalAssessment.Application.DTOs.Item;
using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Application.Interfaces.Services;
using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> GetAllAsync()
    {
        var items = await _itemRepository.GetAllAsync();

        return items.Select(i => new ItemDto
        {
            Id = i.Id,
            ProductId = i.ProductId,
            Quantity = i.Quantity
        });
    }

    public async Task<ItemDto?> GetByIdAsync(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
            return null;

        return new ItemDto
        {
            Id = item.Id,
            ProductId = item.ProductId,
            Quantity = item.Quantity
        };
    }

    public async Task<ItemDto> CreateAsync(CreateItemDto createItemDto)
    {
        var item = new Item
        {
            ProductId = createItemDto.ProductId,
            Quantity = createItemDto.Quantity
        };

        await _itemRepository.AddAsync(item);
        await _itemRepository.SaveChangesAsync();

        return new ItemDto
        {
            Id = item.Id,
            ProductId = item.ProductId,
            Quantity = item.Quantity
        };
    }

    public async Task<ItemDto?> UpdateAsync(int id, UpdateItemDto updateItemDto)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
            return null;

        item.ProductId = updateItemDto.ProductId;
        item.Quantity = updateItemDto.Quantity;

        _itemRepository.Update(item);
        await _itemRepository.SaveChangesAsync();

        return new ItemDto
        {
            Id = item.Id,
            ProductId = item.ProductId,
            Quantity = item.Quantity
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
            return false;

        _itemRepository.Delete(item);
        await _itemRepository.SaveChangesAsync();

        return true;
    }
}