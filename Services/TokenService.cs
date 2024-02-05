using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lobby.Interfaces;
using Lobby.Models;
using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
        _config = config;
    }
    /// <summary>
    /// Génère un token JWT
    /// </summary>
    /// <param name="userId">ID de l'utilisateur</param>
    /// <param name="roles">Roles à avoir</param>
    /// <returns></returns>
    public async Task<string> GenerateToken(GenerateTokenModel model)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, model.UserId)
        };

        foreach (var role in model.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTKey"].ToString()));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "https://murierromain.com",
            audience: "https://murierromain.com",
            claims: claims,
            expires: DateTime.Now.AddMinutes(9),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
