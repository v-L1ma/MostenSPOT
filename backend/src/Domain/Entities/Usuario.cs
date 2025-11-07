using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Você deve preencher o {0}")]
        public string Nome { get; set; }
        
        public Usuario() : base() { }
    }
}