using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa uma publicação no sistema
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Identificador único da publicação
        /// </summary>
        [Key]
        public int PostId { get; set; }

        /// <summary>
        /// ID do usuário que criou a publicação
        /// </summary>
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public required string UserId { get; set; }

        /// <summary>
        /// Usuário que criou a publicação
        /// </summary>
        public required ApplicationUser User { get; set; }

        /// <summary>
        /// ID da comunidade onde a publicação foi feita (opcional)
        /// </summary>
        public int? CommunityId { get; set; }

        /// <summary>
        /// Comunidade onde a publicação foi feita (opcional)
        /// </summary>
        public virtual Community? Community { get; set; }

        /// <summary>
        /// Conteúdo da publicação
        /// </summary>
        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        [MinLength(1, ErrorMessage = "O conteúdo não pode estar vazio")]
        [MaxLength(5000, ErrorMessage = "O conteúdo não pode ter mais de 5000 caracteres")]
        public required string Content { get; set; }

        /// <summary>
        /// Nome do arquivo da imagem anexada à publicação (opcional)
        /// </summary>
        public string? ImageFileName { get; set; }

        /// <summary>
        /// Data de criação da publicação
        /// </summary>
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última atualização da publicação
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Curtidas na publicação
        /// </summary>
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

        /// <summary>
        /// Comentários na publicação
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
} 