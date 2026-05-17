using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public record RegisterDto(
    [Required, EmailAddress] string Email,
    [Required, StringLength(100, MinimumLength = 6)] string Password
);

public record  LoginDto(
    [Required, EmailAddress] string Email,
    [Required] string Password
);

public record AuthResponseDto(
    string Token, 
    string Email,
    DateTime Expiration
);