using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.WebApp.Models.Assinatura;
using PosInfnet.InfnetMusic.WebApp.Services;

namespace PosInfnet.InfnetMusic.WebApp.Controllers
{
    public class AssinaturaController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("InfnetMusicApi");

        public async Task<IActionResult> Index()
        {
            var token = ObterTokenCookie();

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Logar", "Conta");
            }

            var contaId = TokenService.ObterIdPorToken(token);
            var assinaturaId = TokenService.ObterAssinaturaIdPorToken(token);

            List<PlanosAssinaturaModel> planos =
            [
                new("Gratuito", 0),
                new("Mensal", 1),
                new("Anual", 2)
            ];

            if(assinaturaId != null)
            {
                var resultado = await _httpClient.GetAsync($"api/assinatura/{contaId}");

                if (resultado.IsSuccessStatusCode)
                {
                    var assinatura = await resultado.Content.ReadFromJsonAsync<AssinaturaModel>();
                    if (assinatura != null)
                    {
                        assinatura.PlanosAssinaturaModels = planos;
                        return View(assinatura);
                    }
                }
            }

            var assinaturaDto = new AssinaturaModel()
            {
                PlanosAssinaturaModels = planos
            };

            return View(assinaturaDto);
        }

        public async Task<IActionResult> CriarAssinatura(int tipoPlano)
        {
            var token = ObterTokenCookie();

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Logar", "Conta");
            }

            var contaId = TokenService.ObterIdPorToken(token);

            if (contaId == null)
            {
                ModelState.AddModelError(string.Empty, "Erro ao obter token.");
                return View();
            }

            var body = new CriarAssinaturaModel(tipoPlano, contaId);

            var response = await _httpClient.PostAsJsonAsync("api/assinatura/criar", body);

            if (response.IsSuccessStatusCode)
            {
                var resultadoTransacao = response.Content.ReadFromJsonAsync<TransacaoModel>();
                
                if (resultadoTransacao?.Result != null)
                {
                    ViewData["MensagemSucesso"] = resultadoTransacao.Result.Mensagem;
                    return View("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Falha ao obter o token de autenticação.");
            return View();
        }

        private string? ObterTokenCookie()
        {
            return Request.Cookies["InfnetMusic.Token"];
        }
    }
}
