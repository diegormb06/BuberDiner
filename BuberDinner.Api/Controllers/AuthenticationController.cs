using BuberDinner.Application.Services.Authentication;
using BuberDinner.Domain.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authenticationService.Register(request);
        return Ok(registerResult);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest login)
    {
        var loginResult = _authenticationService.Login(login);
        return Ok(loginResult);
    }
}
