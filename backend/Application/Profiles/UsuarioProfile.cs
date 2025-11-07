using AutoMapper;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CadastroUsuarioDTO, Usuario>()
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}