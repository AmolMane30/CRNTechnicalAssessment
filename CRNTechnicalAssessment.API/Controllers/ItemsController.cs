using CRNTechnicalAssessment.Application.DTOs.Item;
using CRNTechnicalAssessment.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRNTechnicalAssessment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetAll()
    {
        var items = await _itemService.GetAllAsync();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetById(int id)
    {
        var item = await _itemService.GetByIdAsync(id);

        if (item == null)
            return NotFound();

        return Ok(item);
    }


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ItemDto>> Create(CreateItemDto createItemDto)
    {
        var createdItem = await _itemService.CreateAsync(createItemDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdItem.Id },
            createdItem);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<ItemDto>> Update(int id, UpdateItemDto updateItemDto)
    {
        var updatedItem = await _itemService.UpdateAsync(id, updateItemDto);

        if (updatedItem == null)
            return NotFound();

        return Ok(updatedItem);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _itemService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}