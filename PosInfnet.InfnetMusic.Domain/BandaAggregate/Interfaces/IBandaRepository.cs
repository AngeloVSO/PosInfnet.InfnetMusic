namespace PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;

public interface IBandaRepository
{
    Task<List<Banda>> ObterBandasAsync();
    Task<List<Banda>> ObterBandasFavoritasAsync(string ContaId);
    Task<Banda?> ObterBandaPorNomeAsync(string Nome);
    Task<Banda?> ObterBandaPorIdAsync(string BandaId);
}
