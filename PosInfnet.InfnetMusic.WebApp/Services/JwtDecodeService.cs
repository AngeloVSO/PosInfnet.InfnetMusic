using System.IdentityModel.Tokens.Jwt;

namespace PosInfnet.InfnetMusic.WebApp.Services;

public class TokenService
{
    public static string DecodeToken(string token, string claimParam ="id")
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Token cannot be null or empty", nameof(token));
        }
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var calimValue = jwtSecurityToken.Claims.First(claim => claim.Type == claimParam).Value;

        return calimValue;
    }

    public static string? ObterIdPorToken(string token)
    {
        var contaId = DecodeToken(token);

        if (!string.IsNullOrEmpty(contaId))
        {
            return contaId;
        }

        return null;
    }
    public static string? ObterAssinaturaIdPorToken(string token)
    {
        var assinaturaId = DecodeToken(token, "assinaturaId");

        if (!string.IsNullOrEmpty(assinaturaId))
        {
            return assinaturaId;
        }

        return null;
    }

    public static string? ObterEmailContaPorToken(string token)
    {
        var email = DecodeToken(token, "email");

        if (!string.IsNullOrEmpty(email))
        {
            return email;
        }

        return null;
    }
}
