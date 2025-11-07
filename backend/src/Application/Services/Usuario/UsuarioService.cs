using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    public UsuarioService(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResponseBase<UsuarioDTO>> EditarUsuario(string id, EditarUsuarioDTO dto)
    {
        string email = dto.Email.Trim().ToLower();
        string nome = dto.Nome.Trim();

        if (id is null)
        {
            throw new Exception("Insira um id válido!");
        }

        Usuario? usuarioBanco = await _userManager.FindByIdAsync(id);

        if (usuarioBanco==null)
        {
            throw new Exception("Nenhum usuario com esse id foi encontrado.");
        }

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nome))
        {
            throw new Exception("Todos os campos são obrigatórios!");
        }

        if (Regex.Match(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success)
        {
            throw new Exception("Email inválido");
        }

        if (nome.Length < 5)
        {
            throw new Exception("O nome deve ter no minimo 5 caracteres");
        }

        if (await _userManager.FindByEmailAsync(email) != null)
        {
            throw new Exception("Email já em uso.");
        }

        // verificar se o nome ou o email é o mesmo e só editar se for diferente
        if (usuarioBanco.Nome == nome || usuarioBanco.Email!.ToLower()  == email)
        {
            throw new Exception("Nenhum dado precisa ser alterado.");
        }

        usuarioBanco.Email = email;
        usuarioBanco.Nome = nome;

        IdentityResult result = await _userManager.UpdateAsync(usuarioBanco);

        if (!result.Succeeded)
        {
            throw new Exception("Ocorreu um erro ao editar o usuário.");
        }

        return new ResponseBase<UsuarioDTO>
        {
            Dados = new UsuarioDTO
            {
                Nome = usuarioBanco.Email,
                Email = usuarioBanco.Nome
            },
            Mensagem = "Usuario editado com sucesso",
        };
    }
}