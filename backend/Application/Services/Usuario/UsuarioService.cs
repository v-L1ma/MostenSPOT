using Microsoft.AspNetCore.Identity;
using AutoMapper;

public class UsuarioService : IUsuarioService
{
    private UserManager<Usuario> _userManager;

    private IMapper _mapper;

    public UsuarioService(UserManager<Usuario> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task CadastraUsuario(CadastroUsuarioDTO cadastroUsuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(cadastroUsuarioDto);
        var resultado = await _userManager.CreateAsync(usuario, cadastroUsuarioDto.Senha);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}