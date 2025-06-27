namespace PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;

public interface IAssinaturaRepository
{
    Task<Assinatura> ObterAssinaturaPorContaIdAsync(Guid contaId);
    Task AtualizarAssinaturaAsync();
}
