using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Domain.Entities;
using CRNTechnicalAssessment.Infrastructure.Data;

namespace CRNTechnicalAssessment.Infrastructure.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}