using Microsoft.EntityFrameworkCore;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.BandaAggregate.ValueObjects;
using PosInfnet.InfnetMusic.Infrastructure.Context;

namespace PosInfnet.InfnetMusic.Infrastructure.Repositories;

public class MusicaRepository(ApplicationDbContext _context) : IMusicaRepository
{
    private readonly ApplicationDbContext _context = _context;

    public async Task<List<Musica>> ObterMusicasAsync()
    {
        return await _context.Musicas
            .AsNoTracking()
            .Include(m => m.Banda)
            .Include(m => m.ContasMusicasFavoritas)
            .ToListAsync();
    }

    public async Task<Musica?> ObterMusicaPorTituloAsync(string Titulo)
    {
        return await _context.Musicas
            .AsNoTracking()
            .Include(m => m.Banda)
            .Include(m => m.ContasMusicasFavoritas)
            .FirstOrDefaultAsync(b => b.Titulo.Contains(Titulo));
    }

    public async Task<List<Musica>> ObterMusicasFavoritasAsync(string ContaId)
    {
        return await _context.Musicas
           .AsNoTracking()
           .Include(m => m.Banda)
           .Where(b => b.ContasMusicasFavoritas.Any(f => f.Id == ContaId))
           .ToListAsync();
    }

    public async Task<Musica?> ObterMusicaPorIdAsync(string MusicaId)
    {
        return await _context.Musicas
            .Include(m => m.Banda)
            .FirstOrDefaultAsync(m => m.Id == MusicaId);
    }
}
