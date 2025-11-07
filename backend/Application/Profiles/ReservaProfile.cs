using AutoMapper;
using backend.Domain.Dtos.Reserva;
using backend.Domain.Entities;

namespace backend.Application.Profiles
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<CriarReservaDTO, Reserva>();
        }
    }
}