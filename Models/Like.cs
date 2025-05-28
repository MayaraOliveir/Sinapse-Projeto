using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa uma curtida em uma publicação
    /// </summary>
    public class Like
    {
        /// <summary>
        /// Identificador único da curtida
        /// </summary>
        [Key]
        public int LikeId { get; set; }

        /// <summary>
        /// ID da publicação que recebeu a curtida
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Publicação que recebeu a curtida
        /// </summary>
        public required Post Post { get; set; }

        /// <summary>
        /// ID do usuário que deu a curtida
        /// </summary>
        [Required(ErrorMessage = "O usuário é obrigatório")]
        public required string UserId { get; set; }

        /// <summary>
        /// Usuário que deu a curtida
        /// </summary>
        public required ApplicationUser User { get; set; }

        /// <summary>
        /// Data de criação da curtida
        /// </summary>
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
} 