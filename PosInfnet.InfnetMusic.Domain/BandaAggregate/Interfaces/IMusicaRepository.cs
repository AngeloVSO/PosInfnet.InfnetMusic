using PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;

namespace PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;

public interface IMusicaRepository
{
    Task<List<Musica>> ObterMusicasAsync();
    Task<Musica?> ObterMusicaPorIdAsync(string MusicaId);
    Task<List<Musica>> ObterMusicasFavoritasAsync(string ContaId);
    Task<List<Musica>> ObterMusicaPorTituloAsync(string Titulo);
}
