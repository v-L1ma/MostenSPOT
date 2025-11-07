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

    /// <summary>
    /// Cadastra um usuário 
    /// </summary>
    /// <param >Objeto com os campos necessários para criação de um usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a criaçao seja feita com sucesso</response>
    [HttpPost("Cadastro")]
    [AllowAnonymous]
    public async Task<IActionResult> CadastraUsuario(CadastroUsuarioDTO cadastroUsuarioDto)
    {
        await _usuarioService.CadastraUsuario(cadastroUsuarioDto);
        return Ok("Usuário cadastrado!");
    }
}