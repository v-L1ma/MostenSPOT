using backend.Domain.Dtos.Reserva;
using Microsoft.AspNetCore.Mvc;

namespace backend.Application.Services.Reserva
{
    public interface IReservaService
    {
        Task CriarReserva([FromBody] CriarReservaDTO criarReservaDTO, string idUsuario);
    }
}