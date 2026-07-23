using CRNTechnicalAssessment.Application.DTOs.Auth;
using CRNTechnicalAssessment.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRNTechnicalAssessment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto registerDto)
    {
        var response = await _authService.RegisterAsync(registerDto);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
    {
        var response = await _authService.LoginAsync(loginDto);

        if (response == null)
            return Unauthorized("Invalid email or password.");

        return Ok(response);
    }
}