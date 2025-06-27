using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.API.DTOs.Banda;
using PosInfnet.InfnetMusic.Application.BandaModule.Interfaces;

namespace PosInfnet.InfnetMusic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BandaController(IBandaService bandaService) : ControllerBase
{
    private readonly IBandaService _bandaService = bandaService;

    [HttpGet("obtertodas")]
    public async Task<IActionResult> ObterBandas([FromQuery] string ContaId)
    {
        if (string.IsNullOrWhiteSpace(ContaId))
        {
            return BadRequest("Informe o Id da conta.");
        }

        var bandas = await _bandaService.ObterBandasAsync(ContaId);

        return bandas is not null
            ? Ok(bandas)
            : NotFound("Nenhuma banda encontrada para a conta informada.");
    }

    [HttpGet("obterpornome")]
    public async Task<IActionResult> ObterBandaPorNome([FromQuery] BandaPorNomeRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var bandas = await _bandaService.ObterBandaPorNomeAsync(request.Nome, request.ContaId);

        return bandas is not null
            ? Ok(bandas)
            : NotFound("Nenhuma banda encontrada para a conta informada.");
    }

    [HttpGet("obterfavoritas")]
    public async Task<IActionResult> ObterBandasFavoritas([FromQuery] string ContaId)
    {
        if (string.IsNullOrWhiteSpace(ContaId))
        {
            return BadRequest("Informe o Id da conta.");
        }

        var bandas = await _bandaService.ObterBandasFavoritasAsync(ContaId);

        return bandas is not null
            ? Ok(bandas)
            : NotFound("Nenhuma banda encontrada para a conta informada.");
    }

    [HttpPost("favoritarbanda")]
    public async Task<IActionResult> FavoritarBanda([FromQuery] AlterarBandaFavoritaRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var resultado = await _bandaService.FavoritarBandaAsync(request.ContaId, request.BandaId);

        return resultado
            ? Ok("Banda favoritada com sucesso.")
            : UnprocessableEntity("Erro de negócio.");
    }

    [HttpPost("desfavoritarbanda")]
    public async Task<IActionResult> DesfavoritarBanda([FromQuery] AlterarBandaFavoritaRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var resultado = await _bandaService.DesfavoritarBandaAsync(request.ContaId, request.BandaId);

        return resultado
            ? Ok("Banda removida de favoritos com sucesso.")
            : UnprocessableEntity("Erro de negócio");
    }
}
