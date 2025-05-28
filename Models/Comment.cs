using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa um comentário em uma publicação
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Identificador único do comentário
        /// </summary>
        [Key]
        public int CommentId { get; set; }

        /// <summary>
        /// ID da publicação que recebeu o comentário
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Publicação que recebeu o comentário
        /// </summary>
        public required Post Post { get; set; }

        /// <summary>
        /// ID do usuário que fez o comentário
        /// </summary>
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public required string UserId { get; set; }

        /// <summary>
        /// Usuário que fez o comentário
        /// </summary>
        public required ApplicationUser User { get; set; }

        /// <summary>
        /// Conteúdo do comentário
        /// </summary>
        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        [MinLength(1, ErrorMessage = "O comentário não pode estar vazio")]
        [MaxLength(1000, ErrorMessage = "O comentário não pode ter mais de 1000 caracteres")]
        public required string Content { get; set; }

        /// <summary>
        /// Data de criação do comentário
        /// </summary>
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última atualização do comentário
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
} 