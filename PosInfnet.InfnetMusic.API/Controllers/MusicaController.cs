using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.API.DTOs.Musica;
using PosInfnet.InfnetMusic.Application.MusicaModule.Interfaces;

namespace PosInfnet.InfnetMusic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicaController(IMusicaService musicaService) : ControllerBase
{
    private readonly IMusicaService _musicaService = musicaService;

    [HttpGet("obtertodas")]
    public async Task<IActionResult> ObterMusicas([FromQuery] string ContaId)
    {
        if (string.IsNullOrWhiteSpace(ContaId))
        {
            return BadRequest("Informe o Id da conta.");
        }

        var musicas = await _musicaService.ObterMusicasAsync(ContaId);

        return musicas is not null
            ? Ok(musicas)
            : NotFound("Nenhuma música encontrada para a conta informada.");
    }

    [HttpGet("obterportitulo")]
    public async Task<IActionResult> ObterMusicasPorTitulo([FromQuery] MusicaPorTituloRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var musicas = await _musicaService.ObterMusicaPorTituloAsync(request.Titulo, request.ContaId);

        return musicas is not null
            ? Ok(musicas)
            : NotFound("Nenhuma música encontrada para a conta informada.");
    }

    [HttpGet("obterfavoritas")]
    public async Task<IActionResult> ObterMusicasFavoritas([FromQuery] string ContaId)
    {
        if (string.IsNullOrWhiteSpace(ContaId))
        {
            return BadRequest("Informe o Id da conta.");
        }

        var musicas = await _musicaService.ObterMusicasFavoritasAsync(ContaId);

        return musicas is not null
            ? Ok(musicas)
            : NotFound("Nenhuma música encontrada para a conta informada.");
    }

    [HttpPut("favoritarmusica")]
    public async Task<IActionResult> FavoritarMusica([FromQuery] AllterarMusicaFavoritaRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var resultado = await _musicaService.FavoritarMusicaAsync(request.ContaId, request.MusicaId);

        return resultado
            ? Ok("Musica favoritada com sucesso.")
            : UnprocessableEntity("Erro de negócio.");
    }

    [HttpDelete("desfavoritarmusica")]
    public async Task<IActionResult> DesfavoritarMusica([FromQuery] AllterarMusicaFavoritaRequest request)
    {
        if (request is null)
        {
            return BadRequest("Dados inválidos.");
        }

        var resultado = await _musicaService.DesfavoritarMusicaAsync(request.ContaId, request.MusicaId);

        return resultado
            ? Ok("Musica removida de favoritas com sucesso.")
            : UnprocessableEntity("Erro de negócio.");
    }
}
