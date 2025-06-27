using PosInfnet.InfnetMusic.Application.ContaModule.Dtos;

namespace PosInfnet.InfnetMusic.API.Services;

public interface ITokenService
{
    public Task<ContaToken> GerarToken(LogarContaDto usuarioDto);
}
