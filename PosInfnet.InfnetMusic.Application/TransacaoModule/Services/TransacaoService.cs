using PosInfnet.InfnetMusic.Application.TransacaoModule.Interfaces;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate;
using PosInfnet.InfnetMusic.Domain.TransacaoAggregate.Interfaces;

namespace PosInfnet.InfnetMusic.Application.TransacaoModule.Services;

public class TransacaoService(ITransacaoRepository transacaoRepository) : ITransacaoService
{
    private readonly ITransacaoRepository _transacaoRepository = transacaoRepository;

    public async Task<Transacao?> ObterTransacaoPorContaIdAsync(string ContaId)
    {
        return await _transacaoRepository.ObterTransacaoPorContaIdAsync(ContaId);
    }

    public async Task<List<Transacao>> ObterTodasTransacoesAsync()
    {
        return await _transacaoRepository.ObterTodasTransacoesAsync();
    }

    public async Task<ResultadoTransacao> AutorizarAsync(Conta conta)
    {
        if (conta.Assinatura == null)
        {
            throw new InvalidOperationException("A conta não possui uma assinatura associada.");
        }

        const string MensagemNotificacao = "Transação de assintura notificada ao comerciente e titular do cartão.";

        var novaTransacao = new Transacao()
        {
            Valor = conta.Assinatura.Preco,
            Conta = conta
        };

        novaTransacao.Autorizar();

        await _transacaoRepository.CriarTransacaoAsync(novaTransacao);
        return new ResultadoTransacao(MensagemNotificacao, DateTime.UtcNow);
    }
}
