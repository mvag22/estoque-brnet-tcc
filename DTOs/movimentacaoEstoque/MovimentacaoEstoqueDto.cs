using System;

namespace ApiBrnetEstoque.DTOs.movimentacaoEstoque
{
    public class MovimentacaoEstoqueDto
    {
        public int IdMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string? Observacao { get; set; }
        public string? TipoMovimentacao { get; set; } // entrada | saida_manual | retirada_tecnico
        public int UsuarioId { get; set; }
    }
}
