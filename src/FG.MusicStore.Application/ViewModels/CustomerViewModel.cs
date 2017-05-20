using System;
using System.ComponentModel.DataAnnotations;

namespace FG.MusicStore.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        [MinLength(3, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é requerido")]       
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        [Display(Name = "E-Mail:")]
        public string Email { get; set; }

    }
}
