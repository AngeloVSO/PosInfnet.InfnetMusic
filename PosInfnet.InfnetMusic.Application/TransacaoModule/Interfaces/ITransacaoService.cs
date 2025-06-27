using PosInfnet.InfnetMusic.Application.TransacaoModule.Services;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate;

namespace PosInfnet.InfnetMusic.Application.TransacaoModule.Interfaces;

public interface ITransacaoService
{   
    Task<Transacao?> ObterTransacaoPorContaIdAsync(string ContaId);
    Task<List<Transacao>> ObterTodasTransacoesAsync();
    Task<ResultadoTransacao> AutorizarAsync(Conta conta);
}
