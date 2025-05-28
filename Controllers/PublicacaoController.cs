using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sinapse.Data;
using Sinapse.Models;
using Sinapse.ViewModels;

namespace Sinapse.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar todas as operações relacionadas a publicações
    /// como criar, editar, excluir, curtir e comentar.
    /// </summary>
    [Authorize] // Garante que apenas usuários logados possam acessar
    public class PublicacaoController : Controller
    {
        private readonly ApplicationDbContext _contexto;
        private readonly UserManager<ApplicationUser> _gerenciadorUsuarios;
        private readonly IWebHostEnvironment _ambiente;

        public PublicacaoController(
            ApplicationDbContext contexto,
            UserManager<ApplicationUser> gerenciadorUsuarios,
            IWebHostEnvironment ambiente)
        {
            _contexto = contexto;
            _gerenciadorUsuarios = gerenciadorUsuarios;
            _ambiente = ambiente;
        }

        /// <summary>
        /// Exibe o formulário para criar uma nova publicação
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            // Carrega a lista de comunidades para o dropdown
            ViewBag.Communities = new SelectList(
                await _contexto.Communities.OrderBy(c => c.Name).ToListAsync(),
                "CommunityId",
                "Name"
            );
            
            return View(new CreatePostViewModel { Content = string.Empty });
        }

        /// <summary>
        /// Processa a criação de uma nova publicação
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Communities = new SelectList(
                    await _contexto.Communities.OrderBy(c => c.Name).ToListAsync(),
                    "CommunityId",
                    "Name"
                );
                return View(model);
            }

            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            if (usuario == null)
            {
                return Challenge();
            }

            string? imageFileName = null;
            if (model.Image != null)
            {
                // Validações da imagem
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(model.Image.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Apenas imagens nos formatos JPG, JPEG, PNG e GIF são permitidas");
                    ViewBag.Communities = new SelectList(
                        await _contexto.Communities.OrderBy(c => c.Name).ToListAsync(),
                        "CommunityId",
                        "Name"
                    );
                    return View(model);
                }

                if (model.Image.Length > 5 * 1024 * 1024) // 5MB
                {
                    ModelState.AddModelError("Image", "O tamanho máximo permitido é 5MB");
                    ViewBag.Communities = new SelectList(
                        await _contexto.Communities.OrderBy(c => c.Name).ToListAsync(),
                        "CommunityId",
                        "Name"
                    );
                    return View(model);
                }

                // Gera um nome único para o arquivo
                var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                var uploadsFolder = Path.Combine(_ambiente.WebRootPath, "uploads", "posts");
                
                // Cria o diretório se não existir
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Salva o arquivo
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                imageFileName = uniqueFileName;
            }

            var novaPublicacao = new Post
            {
                UserId = usuario.Id,
                User = usuario,
                Content = model.Content,
                CommunityId = model.CommunityId,
                ImageFileName = imageFileName
            };

            if (model.CommunityId.HasValue)
            {
                var comunidade = await _contexto.Communities.FindAsync(model.CommunityId);
                if (comunidade != null)
                {
                    novaPublicacao.Community = comunidade;
                }
            }

            _contexto.Posts.Add(novaPublicacao);
            await _contexto.SaveChangesAsync();

            // Se a publicação foi feita em uma comunidade, redireciona para a página da comunidade
            if (model.CommunityId.HasValue)
            {
                var comunidade = await _contexto.Communities.FindAsync(model.CommunityId);
                if (comunidade != null)
                {
                    return RedirectToAction("Details", "Community", new { hashtag = comunidade.Hashtag });
                }
            }

            // Se não, redireciona para o feed geral
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Exibe os detalhes de uma publicação específica
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var publicacao = await _contexto.Posts
                .Include(p => p.User)         // Inclui dados do usuário
                .Include(p => p.Comments)     // Inclui comentários
                    .ThenInclude(c => c.User) // Inclui usuários dos comentários
                .Include(p => p.Likes)        // Inclui curtidas
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        /// <summary>
        /// Processa a ação de curtir/descurtir uma publicação
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Curtir(int id)
        {
            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            if (usuario == null)
            {
                return Challenge();
            }

            var publicacao = await _contexto.Posts
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (publicacao == null)
            {
                return NotFound();
            }

            var curtidaExistente = publicacao.Likes
                .FirstOrDefault(l => l.UserId == usuario.Id);

            bool curtido;
            if (curtidaExistente != null)
            {
                _contexto.Likes.Remove(curtidaExistente);
                curtido = false;
            }
            else
            {
                var novaCurtida = new Like
                {
                    PostId = publicacao.PostId,
                    Post = publicacao,
                    UserId = usuario.Id,
                    User = usuario
                };
                _contexto.Likes.Add(novaCurtida);
                curtido = true;
            }

            await _contexto.SaveChangesAsync();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { 
                    curtido = curtido,
                    totalCurtidas = publicacao.Likes.Count + (curtido ? 1 : -1)
                });
            }

            return RedirectToAction(nameof(Detalhes), new { id });
        }

        /// <summary>
        /// Adiciona um comentário a uma publicação
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comentar(int publicacaoId, string conteudo)
        {
            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            if (usuario == null)
            {
                return Challenge();
            }

            var publicacao = await _contexto.Posts.FindAsync(publicacaoId);
            if (publicacao == null)
            {
                return NotFound();
            }

            var novoComentario = new Comment
            {
                PostId = publicacao.PostId,
                Post = publicacao,
                UserId = usuario.Id,
                User = usuario,
                Content = conteudo
            };

            _contexto.Comments.Add(novoComentario);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Detalhes), new { id = publicacaoId });
        }

        /// <summary>
        /// Exibe o formulário para editar uma publicação
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            var publicacao = await _contexto.Posts.FindAsync(id);

            if (publicacao == null || publicacao.UserId != usuario.Id)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        /// <summary>
        /// Processa a edição de uma publicação
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Post publicacao)
        {
            if (id != publicacao.PostId)
            {
                return NotFound();
            }

            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            var publicacaoExistente = await _contexto.Posts.FindAsync(id);

            if (publicacaoExistente == null || publicacaoExistente.UserId != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                publicacaoExistente.Content = publicacao.Content;
                publicacaoExistente.UpdatedAt = DateTime.Now;

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Detalhes), new { id });
            }

            return View(publicacao);
        }

        /// <summary>
        /// Exibe a confirmação para excluir uma publicação
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            var publicacao = await _contexto.Posts.FindAsync(id);

            if (publicacao == null || publicacao.UserId != usuario.Id)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        /// <summary>
        /// Processa a exclusão de uma publicação
        /// </summary>
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var usuario = await _gerenciadorUsuarios.GetUserAsync(User);
            var publicacao = await _contexto.Posts.FindAsync(id);

            if (publicacao == null || publicacao.UserId != usuario.Id)
            {
                return NotFound();
            }

            _contexto.Posts.Remove(publicacao);
            await _contexto.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
} 