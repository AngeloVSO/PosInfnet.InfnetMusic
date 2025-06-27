using PosInfnet.InfnetMusic.Application.BandaModule.Dtos;

namespace PosInfnet.InfnetMusic.Application.BandaModule.Interfaces;

public interface IBandaService
{
    Task<List<BandaDto>> ObterBandasAsync(string ContaId);
    Task<List<BandaDto>> ObterBandasFavoritasAsync(string ContaId);
    Task<BandaDto?> ObterBandaPorNomeAsync(string Nome, string ContaId);
    Task<bool> FavoritarBandaAsync(string ContaId, string BandaId);
    Task<bool> DesfavoritarBandaAsync(string ContaId, string BandaId);
}
