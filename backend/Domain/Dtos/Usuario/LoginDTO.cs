using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Dtos.Usuario
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public required string Senha { get; set; }
    }
}