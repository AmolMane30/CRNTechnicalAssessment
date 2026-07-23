using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Domain.Entities;
using CRNTechnicalAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRNTechnicalAssessment.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
}