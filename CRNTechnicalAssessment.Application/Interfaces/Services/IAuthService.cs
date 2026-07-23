using CRNTechnicalAssessment.Application.DTOs.Auth;

namespace CRNTechnicalAssessment.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);

    Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
}