using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Login
{
    public class RegisterDto
    {
        [Required] public string Nome { get; set; } = null!;
        [Required] public string UsuarioLogin { get; set; } = null!;
        [Required] public string Senha { get; set; } = null!;
        [Required] public string Perfil { get; set; } = "tecnico"; // ou "admin_estoque"
    }
}
