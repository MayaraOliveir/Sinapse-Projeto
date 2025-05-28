using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Sinapse.ViewModels
{
    public class CreatePostViewModel
    {
        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        [MinLength(1, ErrorMessage = "O conteúdo não pode estar vazio")]
        [MaxLength(5000, ErrorMessage = "O conteúdo não pode ter mais de 5000 caracteres")]
        [Display(Name = "O que você está pensando?")]
        public required string Content { get; set; }

        [Display(Name = "Imagem (opcional)")]
        public IFormFile? Image { get; set; }

        [Display(Name = "Comunidade (opcional)")]
        public int? CommunityId { get; set; }

        public CreatePostViewModel()
        {
            Content = string.Empty;
        }
    }

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
} 