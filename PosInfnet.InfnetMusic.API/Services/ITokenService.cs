namespace PosInfnet.InfnetMusic.API.Services;

public interface ITokenService
{
    public Task<ContaToken> GerarToken(string Email);
}
