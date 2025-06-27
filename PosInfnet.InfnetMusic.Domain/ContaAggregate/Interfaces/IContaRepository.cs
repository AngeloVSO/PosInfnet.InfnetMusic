namespace PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;

public interface IContaRepository
{
    public Task CadastrarContaAsync(Conta Conta);
    public Task<Conta?> ObterContaPorIdAsync(string ContaId);
    public Task<Conta?> ObterContaPorEmailAsync(string Email);
    public Task SalvarAsync();
}
