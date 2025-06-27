using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.API.DTOs.Conta;
using PosInfnet.InfnetMusic.Application.ContaModule.Interfaces;

namespace PosInfnet.InfnetMusic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class AssinaturaController(IContaService contaService) : ControllerBase
{
    private readonly IContaService _contaService = contaService;
    
    [HttpPost("assinatura/criar")]
    public async Task<IActionResult> CriarAssinatura([FromBody] AssinaturaRequest request)
    {
        if (request == null)
        {
            return BadRequest("Dados inválidos para criar assinatura.");
        }

        var resultado = await _contaService.CriarAssinaturaAsync(request.TipoPlano, request.ContaId);
        
        return resultado != null ? Ok(resultado) : UnprocessableEntity("Erro de negócio");
    }
}
