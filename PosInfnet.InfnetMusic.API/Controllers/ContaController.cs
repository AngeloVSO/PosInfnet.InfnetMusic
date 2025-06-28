using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.API.Services;
using PosInfnet.InfnetMusic.Application.ContaModule.Dtos;
using PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;

namespace PosInfnet.InfnetMusic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContaController(ITokenService tokenService, IContaService contaService) : ControllerBase
{
    private readonly ITokenService _tokenService = tokenService;
    private readonly IContaService _contaService = contaService;

    [HttpPost("login")]
    public async Task<IActionResult> LogarConta([FromBody] LogarContaDto LogarContaDto)
    {
        var result = await _contaService.LogarContaAsync(LogarContaDto);

        if (!result)
        {
            return BadRequest("Tentativa de login inválida.");
        }

        var token = await _tokenService.GerarToken(LogarContaDto.Email);
        return Ok(token);
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] CadastrarContaDto CadastrarContaDto)
    {
        if (CadastrarContaDto == null)
        {
            return BadRequest("Dados inválidos para cadastro.");
        }

        var result = await _contaService.CadastrarContaAsync(CadastrarContaDto);

        return result ? Ok(new { message = "Usuário cadastrado com sucesso", email = CadastrarContaDto.Email}) : BadRequest("Falha ao criar usuário.");
    }

    [HttpPost("token")]
    public async Task<IActionResult> TokenConta([FromBody] string Email)
    {
        if (string.IsNullOrEmpty(Email))
        {
            return BadRequest("Dados inválidos.");
        }

        var token = await _tokenService.GerarToken(Email);
        return Ok(token);
    }
}
