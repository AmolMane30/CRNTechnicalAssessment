using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}