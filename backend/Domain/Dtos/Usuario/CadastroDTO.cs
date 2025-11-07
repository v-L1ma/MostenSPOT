using System.ComponentModel.DataAnnotations;

public record CadastroUsuarioDTO
{
    public required string Nome { get; set; }

    [DataType(DataType.EmailAddress)]
    [StringLength(128)]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Senha { get; set; }

    [Compare("Senha")]
    public required string ConfirmarSenha { get; set; }

}