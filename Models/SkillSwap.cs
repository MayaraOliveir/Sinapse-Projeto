using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa uma troca de conhecimento entre dois usuários
    /// </summary>
    public class SkillSwap
    {
        /// <summary>
        /// Identificador único da troca
        /// </summary>
        [Key]
        public int SkillSwapId { get; set; }

        /// <summary>
        /// ID do usuário que solicitou a troca
        /// </summary>
        [Required(ErrorMessage = "O solicitante é obrigatório")]
        public required string RequesterId { get; set; }

        /// <summary>
        /// Usuário que solicitou a troca
        /// </summary>
        public required ApplicationUser Requester { get; set; }

        /// <summary>
        /// ID do usuário que recebeu a solicitação
        /// </summary>
        [Required(ErrorMessage = "O destinatário é obrigatório")]
        public required string AddresseeId { get; set; }

        /// <summary>
        /// Usuário que recebeu a solicitação
        /// </summary>
        public required ApplicationUser Addressee { get; set; }

        /// <summary>
        /// Descrição da habilidade oferecida
        /// </summary>
        [Required(ErrorMessage = "A descrição da habilidade oferecida é obrigatória")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public required string OfferedSkill { get; set; }

        /// <summary>
        /// Descrição da habilidade desejada
        /// </summary>
        [Required(ErrorMessage = "A descrição da habilidade desejada é obrigatória")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres")]
        public required string DesiredSkill { get; set; }

        /// <summary>
        /// Descrição detalhada da proposta de troca
        /// </summary>
        [Required(ErrorMessage = "A descrição da proposta é obrigatória")]
        [StringLength(2000, MinimumLength = 50, ErrorMessage = "A descrição deve ter entre 50 e 2000 caracteres")]
        public required string Description { get; set; }

        /// <summary>
        /// Status da troca (Pendente, Aceita, Recusada, Concluída)
        /// </summary>
        [Required(ErrorMessage = "O status é obrigatório")]
        public required string Status { get; set; } = "Pendente";

        /// <summary>
        /// Data de criação da solicitação
        /// </summary>
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última atualização do status
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Data de conclusão da troca (opcional)
        /// </summary>
        public DateTime? CompletedAt { get; set; }
    }
} 