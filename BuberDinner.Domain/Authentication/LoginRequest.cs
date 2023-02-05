namespace BuberDinner.Domain.Authentication;

public record LoginRequest(
    string Email,
    string Password
);