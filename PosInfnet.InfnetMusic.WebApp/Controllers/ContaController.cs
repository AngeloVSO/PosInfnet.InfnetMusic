using Microsoft.AspNetCore.Mvc;
using PosInfnet.InfnetMusic.WebApp.Models.Conta;

namespace PosInfnet.InfnetMusic.WebApp.Controllers;

public class ContaController(IHttpClientFactory httpClientFactory) : Controller
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("InfnetMusicApi");

    public IActionResult Cadastrar()
    {
        var token = Request.Cookies["InfnetMusic.Token"];

        if (string.IsNullOrEmpty(token))
        {
            return View();
        }

        return RedirectToAction("Index", "Musica");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Cadastrar(CadastrarContaModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var response = _httpClient.PostAsJsonAsync("api/conta/cadastrar", model).Result;

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Logar");
        }

        ModelState.AddModelError(string.Empty, "Falha ao realizar cadastro.");
        return View(model);
    }

    [HttpGet]
    public IActionResult Logar()
    {
        var token = Request.Cookies["InfnetMusic.Token"];

        if (string.IsNullOrEmpty(token))
        {
            return View();
        }

        return RedirectToAction("Index", "Musica");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Logar(LogarContaModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var response = await _httpClient.PostAsJsonAsync("api/conta/login", model);

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponseModel>();
            if (tokenResponse == null)
            {
                ModelState.AddModelError(string.Empty, "Falha ao obter o token de autenticação.");
                return View(model);
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(15)
            };

            Response.Cookies.Append("InfnetMusic.Token", tokenResponse.Token, cookieOptions);

            return RedirectToAction("Index","Musica");
        }

        ModelState.AddModelError(string.Empty, "Falha ao fazer login.");
        return View(model);
    }
}
