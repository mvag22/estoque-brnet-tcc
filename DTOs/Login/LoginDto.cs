using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Login
{
    public class LoginDto
    {
        [Required] public string UsuarioLogin { get; set; } = null!;
        [Required] public string Senha { get; set; } = null!;
    }
}
