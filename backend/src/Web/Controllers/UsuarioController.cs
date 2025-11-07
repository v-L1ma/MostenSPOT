using System.Threading.Tasks;
using backend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    [HttpPut("/{id}")]
    public async Task<ActionResult<ResponseBase<UsuarioDTO>>> EditarUsuario(string id, [FromBody] EditarUsuarioDTO dto)
    {
        // User.FindFirst("Id").Value
        ResponseBase<UsuarioDTO> response = await _usuarioService.EditarUsuario(id, dto);
        return Ok(response);
    }
}