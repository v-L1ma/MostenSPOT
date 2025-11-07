using ReservaModel = backend.Domain.Entities.Reserva;

namespace backend.src.Infraestructure.Data.Repositories.Reserva
{
    public interface IReservaRepository
    {
        Task CriarReserva(ReservaModel reserva);
    }
}