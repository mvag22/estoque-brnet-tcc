using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.movimentacaoMaterial
{
    public class MovimentacaoMaterialUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}
