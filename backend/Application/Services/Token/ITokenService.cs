using backend.Domain.Entities;

namespace backend.Application.Services.Token
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}