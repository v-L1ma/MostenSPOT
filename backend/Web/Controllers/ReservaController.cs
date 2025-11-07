using backend.Application.Services.Reserva;
using backend.Domain.Dtos.Reserva;
using Microsoft.AspNetCore.Mvc;

namespace backend.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : Controller
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost("reservar")]
        public async Task<IActionResult> CriarReserva([FromBody] CriarReservaDTO criarReservaDTO)
        {
            string? idUsuario = User.FindFirst("Id")?.Value;
            await _reservaService.CriarReserva(criarReservaDTO, idUsuario!);
            return Ok();
        }
    }
}