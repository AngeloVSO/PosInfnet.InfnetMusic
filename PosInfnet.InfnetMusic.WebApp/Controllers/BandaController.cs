using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.WebApp.Models.Banda;
using PosInfnet.InfnetMusic.WebApp.Services;

namespace PosInfnet.InfnetMusic.WebApp.Controllers
{
    public class BandaController(IHttpClientFactory httpClientFactory) : Controller
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

            if (contaId == null)
            {
                ModelState.AddModelError(string.Empty, "Erro ao obter token.");
                return View();
            }

            var reponse = await _httpClient.GetAsync($"api/banda/obtertodas?contaId={contaId}");

            if (!reponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Erro ao obter músicas.");
                return View();
            }

            var bandas = await reponse.Content.ReadFromJsonAsync<IEnumerable<BandaModel>>();

            return View(bandas);
        }

        public async Task<IActionResult> FavoritarBanda(string bandaId)
        {
            var token = ObterTokenCookie();

            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError(string.Empty, "Token expirado, logue novamente");
                return View("Index");
            }

            var contaId = TokenService.ObterIdPorToken(token);

            if (contaId == null)
            {
                ModelState.AddModelError(string.Empty, "Erro ao obter token.");
                return View();
            }

            var queryParams = new AlterarBandaFavoritaModel(contaId, bandaId);
            var reponse = await _httpClient.PutAsync($"api/banda/favoritarbanda?contaId={queryParams.ContaId}&bandaId={queryParams.BandaId}", null);

            if (!reponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Erro ao favoritar banda.");
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DesfavoritarBanda(string bandaId)
        {
            var token = ObterTokenCookie();

            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError(string.Empty, "Token expirado, logue novamente");
                return View("Index");
            }

            var contaId = TokenService.ObterIdPorToken(token);

            if (contaId == null)
            {
                ModelState.AddModelError(string.Empty, "Erro ao obter token.");
                return View();
            }

            var queryParams = new AlterarBandaFavoritaModel(contaId, bandaId);
            var reponse = await _httpClient.DeleteAsync($"api/banda/desfavoritarbanda?contaId={queryParams.ContaId}&bandaId={queryParams.BandaId}");

            if (!reponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Erro ao desfavoritar banda.");
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        private string? ObterTokenCookie()
        {
            return Request.Cookies["InfnetMusic.Token"];
        }
    }
}
