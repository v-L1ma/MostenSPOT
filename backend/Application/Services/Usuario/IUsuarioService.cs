using backend.Domain.Dtos.Usuario;

namespace backend.Application.Services
{
    public interface IUsuarioService
    {
        Task<string> Logar(LoginDTO loginDTO);
    }
}