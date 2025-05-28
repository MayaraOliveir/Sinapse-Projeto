using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models;

/// <summary>
/// Representa uma mensagem direta entre dois usuários
/// </summary>
public class DirectMessage
{
    /// <summary>
    /// Identificador único da mensagem
    /// </summary>
    public int DirectMessageId { get; set; }

    /// <summary>
    /// ID do usuário que enviou a mensagem
    /// </summary>
    [Required(ErrorMessage = "O remetente é obrigatório")]
    public required string SenderId { get; set; }

    /// <summary>
    /// Usuário que enviou a mensagem
    /// </summary>
    public required ApplicationUser Sender { get; set; }

    /// <summary>
    /// ID do usuário que recebeu a mensagem
    /// </summary>
    [Required(ErrorMessage = "O destinatário é obrigatório")]
    public required string ReceiverId { get; set; }

    /// <summary>
    /// Usuário que recebeu a mensagem
    /// </summary>
    public required ApplicationUser Receiver { get; set; }

    /// <summary>
    /// Conteúdo da mensagem
    /// </summary>
    [Required(ErrorMessage = "O conteúdo da mensagem é obrigatório")]
    [MinLength(1, ErrorMessage = "A mensagem não pode estar vazia")]
    [MaxLength(1000, ErrorMessage = "A mensagem não pode ter mais de 1000 caracteres")]
    public required string Content { get; set; }

    /// <summary>
    /// Data de envio da mensagem
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Indica se a mensagem foi lida
    /// </summary>
    public bool IsRead { get; set; }

    /// <summary>
    /// Data em que a mensagem foi lida
    /// </summary>
    public DateTime? ReadAt { get; set; }
} 