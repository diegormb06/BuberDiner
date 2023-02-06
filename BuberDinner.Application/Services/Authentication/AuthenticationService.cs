using BuberDinner.Application.Common.interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Authentication;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResponse Login(LoginRequest login)
    {
        if (_userRepository.GetUserByEmail(login.Email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        if (user.Password != login.Password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResponse(user, token);
    }

    public AuthenticationResponse Register(RegisterRequest request)
    {
        if (_userRepository.GetUserByEmail(request.Email) != null)
        {
            throw new Exception("User with given email already exists");
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResponse(user, token);
    }
}
