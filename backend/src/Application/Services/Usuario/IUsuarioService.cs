using backend.Domain.Entities;

public interface IUsuarioService
{
    Task<ResponseBase<UsuarioDTO>> EditarUsuario(string id, EditarUsuarioDTO dto);
}