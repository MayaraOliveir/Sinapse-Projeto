using Microsoft.AspNetCore.Mvc;

namespace Sinapse.Controllers
{
    public class CommunityController : Controller
    {
        // Lista todas as comunidades
        public IActionResult Index()
        {
            return View();
        }

        // Mostra uma comunidade específica
        [Route("comunidade/{hashtag}")]
        public IActionResult Details(string hashtag)
        {
            // TODO: Implementar lógica para buscar posts por hashtag
            ViewData["Hashtag"] = hashtag;
            return View();
        }
    }
} 