using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Material
{
    public class MaterialCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [StringLength(45)]
        public string? Marca { get; set; }

        [StringLength(45)]
        public string? Modelo { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}
