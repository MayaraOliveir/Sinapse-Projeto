using System.ComponentModel.DataAnnotations;

namespace Sinapse.Models
{
    /// <summary>
    /// Representa uma conexão entre dois usuários
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Identificador único da conexão
        /// </summary>
        [Key]
        public int ConnectionId { get; set; }

        /// <summary>
        /// ID do usuário que solicitou a conexão
        /// </summary>
        [Required(ErrorMessage = "O solicitante é obrigatório")]
        public required string RequesterId { get; set; }

        /// <summary>
        /// Usuário que solicitou a conexão
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
        /// Status da conexão (Pendente, Aceita, Recusada)
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
    }
} 