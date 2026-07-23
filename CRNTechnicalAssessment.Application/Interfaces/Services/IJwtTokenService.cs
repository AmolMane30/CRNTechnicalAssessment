using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}