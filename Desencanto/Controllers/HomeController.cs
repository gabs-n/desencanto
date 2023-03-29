using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Desencanto.Models;
using Desencanto.Services;

namespace Desencanto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDsctService _dsctService;

    public HomeController(ILogger<HomeController> logger, IDsctService dsctService)
    {
        _logger = logger;
        _dsctService = dsctService;
    }

    public IActionResult Index(string tipo)
    {
        var persons = _dsctService.GetDesencantoDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(persons);
    }

    public IActionResult Details(int Numero)
    {
        var personagem = _dsctService.GetDetailedPersonagem(Numero);
        return View(personagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
