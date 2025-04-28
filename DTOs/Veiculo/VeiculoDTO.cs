using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Veiculo
{
    public class VeiculoDto
    {
        public int IdVeiculo { get; set; }

        [Required]
        [StringLength(10)]
        public string Placa { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = null!;
    }
}
