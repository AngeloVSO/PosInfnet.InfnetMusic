namespace PosInfnet.InfnetMusic.Domain.TransacaoAggregate.Interfaces;

public interface ITransacaoRepository
{
    Task<Transacao?> ObterTransacaoPorContaIdAsync(string ContaId);
    Task<List<Transacao>> ObterTodasTransacoesAsync();
    Task CriarTransacaoAsync(Transacao Transacao);
}
