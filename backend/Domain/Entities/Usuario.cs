using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Você deve preencher o {0}")]
    public string Nome { get; set; }
    
    public Usuario(string email, string nome) : base()
    {
        Nome = nome;
        Email = email;
        UserName = email;
    }
}
