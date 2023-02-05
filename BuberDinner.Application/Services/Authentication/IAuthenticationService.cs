using BuberDinner.Domain.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResponse Register(RegisterRequest request);
    AuthenticationResponse Login(LoginRequest login);
}
