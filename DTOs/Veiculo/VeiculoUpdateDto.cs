using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Veiculo
{
    public class VeiculoUpdateDto
    {
        [Required]
        [StringLength(10)]
        public string Placa { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = null!;
    }
}
