using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinapse.Models;
using Sinapse.ViewModels;

namespace Sinapse.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel { Email = string.Empty, Password = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new RegisterViewModel 
            { 
                Name = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
                ConfirmPassword = string.Empty
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Profile()
        {
            // Por enquanto retornamos apenas a view, posteriormente implementaremos a lógica de dados
            return View();
        }

        // Action para visualizar perfil de outros usuários
        public IActionResult UserProfile(int id)
        {
            // Dados mockados para teste
            var userModel = new
            {
                Name = "Maria Santos",
                ProfilePhotoUrl = "https://via.placeholder.com/150",
                Bio = "Desenvolvedora Full Stack apaixonada por tecnologia e inovação. Sempre em busca de novos desafios e oportunidades para compartilhar conhecimento.",
                PostsCount = 45,
                ConnectionsCount = 128,
                SkillSwapsCount = 23,
                TeachingSkills = new[] { "Python", "JavaScript", "React", "SQL" },
                LearningSkills = new[] { "UX Design", "Vue.js", "Node.js" },
                Posts = new[]
                {
                    new {
                        Content = "Acabei de aprender uma nova técnica de programação em Python! Alguém interessado em trocar conhecimentos sobre data science? 🐍📊",
                        TimeAgo = "2h",
                        LikesCount = 15,
                        CommentsCount = 5,
                        Tags = new[] { "python", "datascience", "aprendizado" }
                    }
                }
            };

            ViewBag.ConnectionStatus = "not_connected"; // Pode ser: not_connected, pending, connected
            return View(userModel);
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
} 