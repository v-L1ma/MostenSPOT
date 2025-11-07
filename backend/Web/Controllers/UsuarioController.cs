using backend.Application.Services;
using backend.Domain.Dtos.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace backend.Web
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var token = await _usuarioService.Logar(loginDTO);
            return Ok(token);
        }
    }
}