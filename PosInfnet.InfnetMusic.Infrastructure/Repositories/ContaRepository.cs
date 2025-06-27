using Microsoft.EntityFrameworkCore;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Infrastructure.Context;

namespace PosInfnet.InfnetMusic.Infrastructure.Repositories
{
    public class ContaRepository(ApplicationDbContext context) : IContaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarContaAsync(Conta Conta)
        {
            await _context.Contas.AddAsync(Conta);
            await _context.SaveChangesAsync();
        }

        public async Task<Conta?> ObterContaPorIdAsync(string contaId)
        {
            return await _context.Contas
                .Include(c => c.Assinatura)
                .Include(c => c.MusicasFavoritas)
                .Include(c => c.BandasFavoritas)
                .FirstOrDefaultAsync(c => c.Id == contaId);
        }

        public async Task<Conta?> ObterContaPorEmailAsync(string email)
        {
            return await _context.Contas.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
