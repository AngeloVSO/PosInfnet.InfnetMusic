using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.WebApp.Models.Musica;
using PosInfnet.InfnetMusic.WebApp.Services;

namespace PosInfnet.InfnetMusic.WebApp.Controllers;

public class MusicaController(IHttpClientFactory httpClientFactory) : Controller
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

        var reponse = await _httpClient.GetAsync($"api/musica/obtertodas?contaId={contaId}");

        if (!reponse.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Erro ao obter músicas.");
            return View();
        }

        var musicas = await reponse.Content.ReadFromJsonAsync<IEnumerable<MusicaModel>>();

        return View(musicas);
    }

    public async Task<IActionResult> FavoritarMusica(string musicaId)
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

        var queryParams = new AlterarMusicaFavoritaModel(contaId, musicaId);
        var reponse = await _httpClient.PutAsync($"api/musica/favoritarmusica?contaId={queryParams.ContaId}&musicaId={queryParams.MusicaId}", null);

        if (!reponse.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Erro ao favoritar música.");
            return View("Index");
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DesfavoritarMusica(string musicaId)
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

        var queryParams = new AlterarMusicaFavoritaModel(contaId, musicaId);
        var reponse = await _httpClient.DeleteAsync($"api/musica/desfavoritarmusica?contaId={queryParams.ContaId}&musicaId={queryParams.MusicaId}");

        if (!reponse.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Erro ao desfavoritar música.");
            return View("Index");
        }

        return RedirectToAction("Index");
    }

    private string? ObterTokenCookie()
    {
        return Request.Cookies["InfnetMusic.Token"];
    }
}