using BuberDinner.Domain.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResponse Login(LoginRequest login)
    {
        return new AuthenticationResponse(
            "Diego",
            "Rodrigues",
            "diego@email.com",
            Guid.NewGuid().ToString()
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
