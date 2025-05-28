using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Sinapse.Models;

/// <summary>
/// Representa um usuário no sistema
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Nome completo do usuário
    /// </summary>
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
    public required string Name { get; set; }

    /// <summary>
    /// Biografia do usuário (opcional)
    /// </summary>
    [StringLength(500, ErrorMessage = "A biografia não pode ter mais de 500 caracteres")]
    public string? Biography { get; set; }

    /// <summary>
    /// URL da foto de perfil do usuário
    /// </summary>
    [StringLength(255)]
    [Url(ErrorMessage = "A URL da foto de perfil é inválida")]
    public string ProfilePhotoUrl { get; set; } = "/images/default-avatar.png";

    /// <summary>
    /// Data de criação da conta
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Data da última atualização do perfil
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Publicações feitas pelo usuário
    /// </summary>
    public ICollection<Post> Posts { get; set; } = new List<Post>();

    /// <summary>
    /// Comentários feitos pelo usuário
    /// </summary>
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    /// <summary>
    /// Curtidas dadas pelo usuário
    /// </summary>
    public ICollection<Like> Likes { get; set; } = new List<Like>();

    /// <summary>
    /// Comunidades criadas pelo usuário
    /// </summary>
    public ICollection<Community> CreatedCommunities { get; set; } = new List<Community>();

    /// <summary>
    /// Mensagens enviadas pelo usuário
    /// </summary>
    public ICollection<DirectMessage> SentMessages { get; set; } = new List<DirectMessage>();

    /// <summary>
    /// Mensagens recebidas pelo usuário
    /// </summary>
    public ICollection<DirectMessage> ReceivedMessages { get; set; } = new List<DirectMessage>();

    /// <summary>
    /// Conexões solicitadas pelo usuário
    /// </summary>
    public ICollection<Connection> RequestedConnections { get; set; } = new List<Connection>();

    /// <summary>
    /// Conexões recebidas pelo usuário
    /// </summary>
    public ICollection<Connection> ReceivedConnections { get; set; } = new List<Connection>();

    /// <summary>
    /// Trocas de conhecimento solicitadas pelo usuário
    /// </summary>
    public ICollection<SkillSwap> RequestedSkillSwaps { get; set; } = new List<SkillSwap>();

    /// <summary>
    /// Trocas de conhecimento recebidas pelo usuário
    /// </summary>
    public ICollection<SkillSwap> ReceivedSkillSwaps { get; set; } = new List<SkillSwap>();

    /// <summary>
    /// Notificações do usuário
    /// </summary>
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
} 