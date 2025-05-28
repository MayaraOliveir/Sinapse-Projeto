using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sinapse.Data;
using Sinapse.Models;
using Microsoft.AspNetCore.Authorization;

namespace Sinapse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _contexto;

    public HomeController(
        ILogger<HomeController> logger,
        ApplicationDbContext contexto)
    {
        _logger = logger;
        _contexto = contexto;
    }

    public async Task<IActionResult> Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        // Carrega as publicações mais recentes com seus relacionamentos
        var publicacoes = await _contexto.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .Include(p => p.Community)
            .OrderByDescending(p => p.CreatedAt)
            .Take(20) // Limita a 20 publicações mais recentes
            .ToListAsync();

        return View(publicacoes);
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
