using ReservaModel = backend.Domain.Entities.Reserva;

namespace backend.src.Infraestructure.Data.Repositories.Reserva
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CriarReserva(ReservaModel reserva)
        {
            _context.Add(reserva);
            await _context.SaveChangesAsync();
        }
    }
}