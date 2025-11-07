using AutoMapper;
using backend.Domain.Dtos.Reserva;
using backend.src.Infraestructure.Data.Repositories.Reserva;
using Microsoft.AspNetCore.Mvc;
using ReservaModel = backend.Domain.Entities.Reserva;

namespace backend.Application.Services.Reserva
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper _mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task CriarReserva([FromBody] CriarReservaDTO criarReservaDTO, string idUsuario)
        {
            if (idUsuario is null)
                throw new ApplicationException("Usuário não autenticado!");

            if (criarReservaDTO.DataHoraReserva == default)
                throw new ApplicationException("Você deve inserir uma data e hora para sua reserva!");

            if (criarReservaDTO.DataHoraReserva < DateTime.UtcNow)
                throw new ApplicationException("Data e hora de agendamento deve ser posterior ao tempo presente!");

            if (criarReservaDTO.LugarId <= 0 || criarReservaDTO.LugarId > 90)
                throw new ApplicationException("Escolha um lugar para sua reserva!");

            var reserva = _mapper.Map<ReservaModel>(criarReservaDTO);
            reserva.UsuarioId = idUsuario;

            await _reservaRepository.CriarReserva(reserva);
        }
    }
}