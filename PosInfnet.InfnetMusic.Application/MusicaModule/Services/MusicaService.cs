using PosInfnet.InfnetMusic.Application.MusicaModule.Dtos;
using PosInfnet.InfnetMusic.Application.MusicaModule.Interfaces;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;

namespace PosInfnet.InfnetMusic.Application.MusicaModule.Services;

public class MusicaService(IMusicaRepository musicaRepository, IContaRepository contaRepository) : IMusicaService
{
    private readonly IMusicaRepository _musicaRepository = musicaRepository;
    private readonly IContaRepository _contaRepository = contaRepository;

    public async Task<List<MusicaDto>> ObterMusicasAsync(string ContaId)
    {
        var musicas = await _musicaRepository.ObterMusicasAsync();

        return [.. musicas.Select(m => new MusicaDto
        {
            Id = m.Id,
            Titulo = m.Titulo,
            BandaId = m.Banda.Id,
            BandaNome = m.Banda.Nome,
            EhFavorita = m.ContasMusicasFavoritas.Any(f => f.Id == ContaId),
        })];
    }

    public async Task<MusicaDto?> ObterMusicaPorTituloAsync(string Titulo, string ContaId)
    {
        var musica = await _musicaRepository.ObterMusicaPorTituloAsync(Titulo);

        if (musica == null)
        {
            return default;
        }

        return new MusicaDto
        {
            Id = musica.Id,
            Titulo = musica.Titulo,
            BandaId = musica.Banda.Id,
            BandaNome = musica.Banda.Nome,
            EhFavorita = musica.ContasMusicasFavoritas.Any(f => f.Id == ContaId),
        };
    }

    public async Task<List<MusicaDto>> ObterMusicasFavoritasAsync(string ContaId)
    {
        var musicas = await _musicaRepository.ObterMusicasFavoritasAsync(ContaId);

        return [.. musicas.Select(m => new MusicaDto
        {
            Id = m.Id,
            Titulo = m.Titulo,
            BandaId = m.Banda.Id,
            BandaNome = m.Banda.Nome,
            EhFavorita = true
        })];
    }

    public async Task<bool> FavoritarMusicaAsync(string ContaId, string MusicaId)
    {
        var conta = await _contaRepository.ObterContaPorIdAsync(ContaId);
        var musica = await _musicaRepository.ObterMusicaPorIdAsync(MusicaId);

        if (conta == null || musica == null)
        {
            return false;
        }
        
        conta.FavoritarMusica(musica);
        await _contaRepository.SalvarAsync();
        return true;
    }

    public async Task<bool> DesfavoritarMusicaAsync(string ContaId, string MusicaId)
    {
        var conta = await _contaRepository.ObterContaPorIdAsync(ContaId);
        var musica = await _musicaRepository.ObterMusicaPorIdAsync(MusicaId);

        if (conta == null || musica == null)
        {
            return false;
        }

        conta.DesfavoritarMusica(musica);
        await _contaRepository.SalvarAsync();
        return true;
    }
}
