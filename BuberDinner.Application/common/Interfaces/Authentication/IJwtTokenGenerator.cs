namespace BuberDinner.Application.Common.interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(Guid userId, string firstName, string lastName);
}
