using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers;

public static class AuthController
{
    // POST: /api/auth/register
    public static async Task<IResult>Register(RegisterDto dto, UserManager<IdentityUser> userManager)
    {
        var userExists = await userManager.FindByEmailAsync(dto.Email);
        if (userExists != null) return Results.BadRequest("El correo electrónico ya está registrado.");

        var user = new IdentityUser {UserName = dto.Email, Email = dto.Email};
        var result = await userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return Results.BadRequest(new {Errors = errors});
        } 

        return Results.Ok(new { Message = "Usuario registrado exitosamente"});
    }

    // POST: /api/auth/login
    public static async Task<IResult> Login(LoginDto dto, UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
        {
            return Results.Unauthorized();
        }

        //generate claims (payload of JWT)
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //Create the cryptographic signature
        var jwtSettings = configuration.GetSection("Jwt");
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["key"]!));
        var expirationTime = DateTime.UtcNow.AddHours(3);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["issuer"],
            audience: jwtSettings["Audience"],
            expires: expirationTime,
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(new AuthResponseDto(tokenString, user.Email!, expirationTime));

    }
}