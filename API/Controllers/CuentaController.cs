using API.Dtos.Usuarios;
using API.Errors;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class CuentaController : BaseApiController
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ITokenService _tokenService;

        public CuentaController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]

        public async Task<ActionResult<UsuarioDto>> ObtenerUsuarioActual()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var usuario = await _userManager.FindByEmailAsync(email);

            return new UsuarioDto
            {
                Email = usuario.Email,
                Token = _tokenService.CrearToken(usuario),
                NombreMostrar = usuario.NombreAMostrar
            };

        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await _userManager.FindByEmailAsync(loginDto.Email);

            if(usuario == null)
            {
                return Unauthorized(new ApiRespuesta(401));
            }

            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, loginDto.Contrasena, false);

            if(!resultado.Succeeded)
            {
                return Unauthorized(new ApiRespuesta(401));
            }

            return new UsuarioDto
            {
                Email = usuario.Email,
                Token = _tokenService.CrearToken(usuario),
                NombreMostrar = usuario.NombreAMostrar
            };
        }
    }
}