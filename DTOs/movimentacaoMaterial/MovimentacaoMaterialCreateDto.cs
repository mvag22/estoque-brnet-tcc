using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.movimentacaoMaterial
{
    public class MovimentacaoMaterialCreateDto
    {
        [Required]
        public int MovimentacaoEstoqueId { get; set; }

        [Required]
        public int MaterialEstoqueId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}
