using Microsoft.IdentityModel.Tokens;
using PosInfnet.InfnetMusic.Application.ContaModule.Dtos;
using PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PosInfnet.InfnetMusic.API.Services;

public sealed class TokenService(IConfiguration configuration, IContaService contaService) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IContaService _contaService = contaService;

    public async Task<ContaToken> GerarToken(LogarContaDto usuarioDto)
    {
        var conta = await _contaService.ObterUsuarioPorEmailAsync(usuarioDto.Email) ?? throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

        var claims = new List<Claim>
        {
            new("id", conta.Id),
            new("email", conta.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(15);

        JwtSecurityToken token = new(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new ContaToken(new JwtSecurityTokenHandler().WriteToken(token), expiration);
    }
}
