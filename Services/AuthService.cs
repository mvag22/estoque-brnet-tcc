using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.DTOs.Login;
using Microsoft.EntityFrameworkCore;

namespace ApiBrnetEstoque.Services
{
    public class AuthService
    {
        private readonly BdBrnetEstoqueContext _ctx;
        private readonly IPasswordHasher<Usuario> _hasher;
        private readonly IConfiguration _config;

        public AuthService(
            BdBrnetEstoqueContext ctx,
            IPasswordHasher<Usuario> hasher,
            IConfiguration config)
        {
            _ctx = ctx;
            _hasher = hasher;
            _config = config;
        }

        public async Task<Usuario> RegisterAsync(RegisterDto dto)
        {
            if (_ctx.Usuarios.Any(u => u.Usuario1 == dto.UsuarioLogin))
                throw new ApplicationException("Login já cadastrado.");

            var u = new Usuario
            {
                Nome = dto.Nome,
                Usuario1 = dto.UsuarioLogin,
                Perfil = dto.Perfil
            };
            u.Senha = _hasher.HashPassword(u, dto.Senha);
            _ctx.Usuarios.Add(u);
            await _ctx.SaveChangesAsync();
            return u;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _ctx.Usuarios
                       .FirstOrDefaultAsync(u => u.Usuario1 == dto.UsuarioLogin);
            if (user == null)
                throw new ApplicationException("Usuário não encontrado.");

            var res = _hasher.VerifyHashedPassword(user, user.Senha, dto.Senha);
            if (res == PasswordVerificationResult.Failed)
                throw new ApplicationException("Senha incorreta.");

            // montar token
            var jwt = _config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwt["Key"]!);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Usuario1),
                new Claim(ClaimTypes.Role, user.Perfil),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var creds = new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4),
                signingCredentials: creds);

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
