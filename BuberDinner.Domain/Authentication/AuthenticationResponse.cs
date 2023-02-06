using BuberDinner.Domain.Entities;

namespace BuberDinner.Domain.Authentication;

public record AuthenticationResponse(
    User User,
    string Token
);