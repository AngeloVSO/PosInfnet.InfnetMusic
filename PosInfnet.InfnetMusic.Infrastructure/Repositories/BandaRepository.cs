using Microsoft.EntityFrameworkCore;
using PosInfnet.InfnetMusic.Domain.BandaAggregate;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Infrastructure.Context;

namespace PosInfnet.InfnetMusic.Infrastructure.Repositories;

public class BandaRepository(ApplicationDbContext context) : IBandaRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Banda?> ObterBandaPorIdAsync(string BandaId)
    {
        return await _context.Bandas
             .Include(b => b.Musicas)
             .FirstOrDefaultAsync(b => b.Id == BandaId);
    }

    public async Task<Banda?> ObterBandaPorNomeAsync(string Nome)
    {
        return await _context.Bandas
            .AsNoTracking()
            .Include(b => b.Musicas)
            .Include(b => b.ContasBandasFavoritas)
            .FirstOrDefaultAsync(b => b.Nome.Contains(Nome));
    }

    public async Task<List<Banda>> ObterBandasAsync()
    {
        return await _context.Bandas
            .AsNoTracking()
            .Include(b => b.Musicas)
            .Include(b => b.ContasBandasFavoritas)
            .ToListAsync();
    }

    public async Task<List<Banda>> ObterBandasFavoritasAsync(string ContaId)
    {
        return await _context.Bandas
            .AsNoTracking()
            .Include(b => b.Musicas)
            .Where(b => b.ContasBandasFavoritas.Any(f => f.Id == ContaId))
            .ToListAsync();
    }
}
