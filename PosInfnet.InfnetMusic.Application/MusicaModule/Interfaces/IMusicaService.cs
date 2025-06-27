using PosInfnet.InfnetMusic.Application.MusicaModule.Dtos;

namespace PosInfnet.InfnetMusic.Application.MusicaModule.Interfaces;

public interface IMusicaService
{
    Task<List<MusicaDto>> ObterMusicasAsync(string ContaId);
    Task<List<MusicaDto>> ObterMusicasFavoritasAsync(string ContaId);
    Task<MusicaDto?> ObterMusicaPorTituloAsync(string Titulo, string ContaId);
    Task<bool> FavoritarMusicaAsync(string ContaId, string MusicaId);
    Task<bool> DesfavoritarMusicaAsync(string ContaId, string MusicaId);
}
