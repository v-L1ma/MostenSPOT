using backend.Application.Services.Token;
using backend.Domain.Dtos.Usuario;
using backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ITokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Logar(LoginDTO loginDTO)
        {
            var resultado = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Senha, false, false);

            if (!resultado.Succeeded)
                throw new ApplicationException("Email ou senha inválido.");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.Email == loginDTO.Email);

            var token = _tokenService.GerarToken(usuario!);
            return token;
        }
    }
}