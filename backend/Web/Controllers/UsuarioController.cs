using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("Cadastro")]
    [AllowAnonymous]
    public async Task<IActionResult> CadastraUsuario(CadastroUsuarioDTO cadastroUsuarioDto)
    {
        await _usuarioService.CadastraUsuario(cadastroUsuarioDto);
        return Ok("Usuário cadastrado!");
    }
}