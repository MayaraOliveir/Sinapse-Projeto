using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models;

/// <summary>
/// Representa uma notificação para um usuário
/// </summary>
public class Notification
{
    /// <summary>
    /// Identificador único da notificação
    /// </summary>
    [Key]
    public int NotificationId { get; set; }

    /// <summary>
    /// ID do usuário que recebeu a notificação
    /// </summary>
    [Required(ErrorMessage = "O usuário é obrigatório")]
    public required string UserId { get; set; }

    /// <summary>
    /// Usuário que recebeu a notificação
    /// </summary>
    public required ApplicationUser User { get; set; }

    /// <summary>
    /// Tipo da notificação (Curtida, Comentário, Conexão, etc.)
    /// </summary>
    [Required(ErrorMessage = "O tipo é obrigatório")]
    [StringLength(50, ErrorMessage = "O tipo não pode ter mais de 50 caracteres")]
    public required string Type { get; set; }

    /// <summary>
    /// Conteúdo da notificação
    /// </summary>
    [Required(ErrorMessage = "O conteúdo é obrigatório")]
    [StringLength(500, ErrorMessage = "O conteúdo não pode ter mais de 500 caracteres")]
    public required string Content { get; set; }

    /// <summary>
    /// Link relacionado à notificação (opcional)
    /// </summary>
    [StringLength(255)]
    [Url(ErrorMessage = "O link é inválido")]
    public string? Link { get; set; }

    /// <summary>
    /// Data de criação da notificação
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Indica se a notificação foi lida
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// Data em que a notificação foi lida
    /// </summary>
    public DateTime? ReadAt { get; set; }
} 