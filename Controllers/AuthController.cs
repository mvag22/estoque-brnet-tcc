using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.Services;
using ApiBrnetEstoque.DTOs.Login;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
            => _authService = authService;

        /// Registra um novo usuário (técnico ou admin_estoque).
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            try
            {
                var user = await _authService.RegisterAsync(dto);
                return Ok(new
                {
                    user.IdUsuario,
                    user.Nome,
                    user.Usuario1
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

       /// Autentica usuário e retorna um JWT.
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var authResponse = await _authService.LoginAsync(dto);
                return Ok(authResponse);
            }
            catch (ApplicationException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
