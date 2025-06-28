using PosInfnet.InfnetMusic.Application.ContaModule.Dtos;
using PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;
using PosInfnet.InfnetMusic.Application.TransacaoModule.Interfaces;
using PosInfnet.InfnetMusic.Application.TransacaoModule.Services;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Enums;
using PosInfnet.InfnetMusic.Domain.ContaAggregate.Interfaces;

namespace PosInfnet.InfnetMusic.Application.ContaModule.Services;

public class ContaService(IContaRepository contaRepository, ITransacaoService transacaoService) : IContaService
{
    private readonly IContaRepository _contaRepository = contaRepository;
    private readonly ITransacaoService _transacaoService = transacaoService;

    public async Task<bool> CadastrarContaAsync(CadastrarContaDto cadastrarContaDto)
    {
        var senhaHash = BCrypt.Net.BCrypt.HashPassword(cadastrarContaDto.Senha, 12);

        var novaConta = new Conta
        {
            Nome = cadastrarContaDto.Nome,
            Email = cadastrarContaDto.Email,
            SenhaHash = senhaHash
        };

        try
        {
            await _contaRepository.CadastrarContaAsync(novaConta);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> LogarContaAsync(LogarContaDto logarContaDto)
    {
        var conta = await ObterContaPorEmailAsync(logarContaDto.Email);

        if (conta != null && BCrypt.Net.BCrypt.Verify(logarContaDto.Senha, conta.SenhaHash))
        {
            return true;
        }

        return false;
    }

    public async Task<Conta?> ObterContaPorEmailAsync(string email)
    {
        return await _contaRepository.ObterContaPorEmailAsync(email);
    }

    public async Task<ResultadoTransacao?> CriarAssinaturaAsync(int tipoPlano, string contaId)
    {
        var conta = await _contaRepository.ObterContaPorIdAsync(contaId);

        if (conta == null)
        {
            return default;
        }

        var novaAssinatura = new Assinatura
        {
            Plano = (TipoPlano)tipoPlano,
            Preco = ObterPrecoParaPlano((TipoPlano)tipoPlano),
            Conta = conta
        };

        conta.CriarAssinatura(novaAssinatura);

        var resultadoTransacao = await AutorizarTransacaoAsync(conta);

        await _contaRepository.SalvarAsync();
        return resultadoTransacao;
    }

    private async Task<ResultadoTransacao?> AutorizarTransacaoAsync(Conta conta)
    {
        if (conta.Assinatura == null)
        {
            return default;
        }

        return await _transacaoService.AutorizarAsync(conta);
    }

    private static decimal ObterPrecoParaPlano(TipoPlano plano)
    {
        return plano switch
        {
            TipoPlano.Gratuito => 0.00m,
            TipoPlano.Mensal => 19.90m,
            _ => 199.90m,
        };
    }

    public async Task<Conta?> ObterContaPorIdAsync(string ContaId)
    {
        return await _contaRepository.ObterContaPorIdAsync(ContaId);
    }
}
