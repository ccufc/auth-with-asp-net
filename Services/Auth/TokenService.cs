using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services.Auth;

public class TokenService
{
    public static string Generate(int id, string email)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new (JwtRegisteredClaimNames.Sub, id.ToString()),
            new (JwtRegisteredClaimNames.Email, email),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Typ, "at+jwt")
        };

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddMinutes(6),
            notBefore: DateTime.Now
        );

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }

    public static bool Validate(string token)
    {
        var parameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key.secret)),
            RequireSignedTokens = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false
        };

        var handler = new JwtSecurityTokenHandler();

        try
        {
            handler.ValidateToken(token, parameters, out _);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    public static string GetSub(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var claims = handler.ReadJwtToken(token).Claims;
        var sub = claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
        return sub;
    }
}
