using Microsoft.EntityFrameworkCore;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate.Interfaces;
using PosInfnet.InfnetMusic.Infrastructure.Context;

namespace PosInfnet.InfnetMusic.Infrastructure.Repositories;

public class TransacaoRepository(ApplicationDbContext context) : ITransacaoRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Transacao?> ObterTransacaoPorContaIdAsync(string ContaId)
    {
        return await _context.Transacoes.Include(t => t.Conta).FirstOrDefaultAsync(t => t.Conta.Id == ContaId);
    }

    public async Task<List<Transacao>> ObterTodasTransacoesAsync()
    {
        return await _context.Transacoes.ToListAsync() ?? throw new KeyNotFoundException("Transações não encontradas.");
    }

    public async Task CriarTransacaoAsync(Transacao transacao)
    {
        await _context.Transacoes.AddAsync(transacao);
        await _context.SaveChangesAsync();
    }
}
