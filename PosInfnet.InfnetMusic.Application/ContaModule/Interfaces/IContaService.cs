using PosInfnet.InfnetMusic.Application.ContaModule.Dtos;
using PosInfnet.InfnetMusic.Application.TransacaoModule.Services;
using PosInfnet.InfnetMusic.Domain.ContaAggregate;

namespace PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;

public interface IContaService
{
    public Task<bool> CadastrarContaAsync(CadastrarContaDto ContaDto);
    public Task<bool> LogarContaAsync(LogarContaDto LogarContaDto);
    public Task<Conta?> ObterUsuarioPorEmailAsync(string Email);
    public Task<ResultadoTransacao?> CriarAssinaturaAsync(int TipoPlano, string ContaId);
}
