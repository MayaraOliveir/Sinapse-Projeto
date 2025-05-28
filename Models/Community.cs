using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa uma comunidade no sistema
    /// </summary>
    public class Community
    {
        /// <summary>
        /// Identificador único da comunidade
        /// </summary>
        [Key]
        public int CommunityId { get; set; }

        /// <summary>
        /// Nome da comunidade
        /// </summary>
        [Required(ErrorMessage = "O nome da comunidade é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        public required string Name { get; set; }

        /// <summary>
        /// Hashtag única da comunidade
        /// </summary>
        [Required(ErrorMessage = "A hashtag é obrigatória")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "A hashtag deve ter entre 2 e 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "A hashtag pode conter apenas letras, números e underscore")]
        public required string Hashtag { get; set; }

        /// <summary>
        /// Descrição da comunidade
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public required string Description { get; set; }

        /// <summary>
        /// Data de criação da comunidade
        /// </summary>
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última atualização da comunidade
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID do usuário que criou a comunidade
        /// </summary>
        [Required(ErrorMessage = "O criador da comunidade é obrigatório")]
        public required string CreatedByUserId { get; set; }

        /// <summary>
        /// Usuário que criou a comunidade
        /// </summary>
        public required ApplicationUser CreatedByUser { get; set; }

        /// <summary>
        /// Publicações feitas na comunidade
        /// </summary>
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
} 