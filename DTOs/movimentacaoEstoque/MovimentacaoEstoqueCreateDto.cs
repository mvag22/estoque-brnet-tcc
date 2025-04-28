using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs
{
    public class MovimentacaoEstoqueCreateDto
    {
        [Required]
        public int MaterialId { get; set; }     

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [RegularExpression("entrada|saida_manual|retirada_tecnico")]
        public string TipoMovimentacao { get; set; } = null!;

        [Required]
        public int UsuarioId { get; set; }
    }
}
