using PosInfnet.InfnetMusic.Application.BandaModule.Dtos;
using PosInfnet.InfnetMusic.Application.BandaModule.Interfaces;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;

namespace PosInfnet.InfnetMusic.Application.BandaModule.Services;

public class BandaService(IBandaRepository bandaRepository, IContaRepository contaRepository) : IBandaService
{
    private readonly IBandaRepository _bandaRepository = bandaRepository;
    private readonly IContaRepository _contaRepository = contaRepository;

    public async Task<BandaDto?> ObterBandaPorNomeAsync(string Nome, string ContaId)
    {
        var banda = await _bandaRepository.ObterBandaPorNomeAsync(Nome);

        if (banda == null)
        {
            return null;
        }

        return new BandaDto
        {
            Id = banda.Id,
            Nome = banda.Nome,
            EhFavorita = banda.ContasBandasFavoritas.Any(f => f.Id == ContaId)
        };
    }

    public async Task<List<BandaDto>> ObterBandasAsync(string ContaId)
    {
        var bandas = await _bandaRepository.ObterBandasAsync();

        return [.. bandas.Select(b => new BandaDto
        {
            Id = b.Id,
            Nome = b.Nome,
            EhFavorita = b.ContasBandasFavoritas.Any(f => f.Id == ContaId),
        })];
    }

    public async Task<List<BandaDto>> ObterBandasFavoritasAsync(string ContaId)
    {
        var bandas = await _bandaRepository.ObterBandasFavoritasAsync(ContaId);

        return [.. bandas.Select(b => new BandaDto
        {
            Id = b.Id,
            Nome = b.Nome,
            EhFavorita = true
        })];
    }

    public async Task<bool> FavoritarBandaAsync(string ContaId, string BandaId)
    {
        var banda = await _bandaRepository.ObterBandaPorIdAsync(BandaId);
        var conta = await _contaRepository.ObterContaPorIdAsync(ContaId);

        if (banda == null || conta == null)
        {
            return false;
        }
        
        conta.FavoritarBanda(banda);
        await _contaRepository.SalvarAsync();
        return true;
    }

    public async Task<bool> DesfavoritarBandaAsync(string ContaId, string BandaId)
    {
        var banda = await _bandaRepository.ObterBandaPorIdAsync(BandaId);
        var conta = await _contaRepository.ObterContaPorIdAsync(ContaId);

        if (banda == null || conta == null)
        {
            return false;
        }

        conta.DesfavoritarBanda(banda);
        await _contaRepository.SalvarAsync();
        return true;
    }
}
