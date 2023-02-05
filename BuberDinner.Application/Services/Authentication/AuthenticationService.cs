using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Domain.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResponse Login(LoginRequest login)
    {
        var token = _jwtTokenGenerator.GenerateJwtToken(
            Guid.NewGuid(),
            "Diego",
            "Rodrigues"
        );

        return new AuthenticationResponse(
            "Diego",
            "Rodrigues",
            "diego@email.com",
            token
        );
    }

    public AuthenticationResponse Register(RegisterRequest request)
    {
        return new AuthenticationResponse(
            "Diego",
            "Rodrigues",
            "diego@email.com",
            Guid.NewGuid().ToString()
        );
    }
}
