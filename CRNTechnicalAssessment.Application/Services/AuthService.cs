using BCrypt.Net;
using CRNTechnicalAssessment.Application.DTOs.Auth;
using CRNTechnicalAssessment.Application.Interfaces.Repositories;
using CRNTechnicalAssessment.Application.Interfaces.Services;
using CRNTechnicalAssessment.Domain.Entities;

namespace CRNTechnicalAssessment.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);

        if (existingUser != null)
        {
            throw new Exception("User already exists.");
        }

        var user = new User
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            Role = "User"
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var token = _jwtTokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);

        if (user == null)
            return null;

        bool validPassword = BCrypt.Net.BCrypt.Verify(
            loginDto.Password,
            user.PasswordHash);

        if (!validPassword)
            return null;

        var token = _jwtTokenService.GenerateToken(user);

        return new AuthResponseDto
        {
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }
}