using System;

namespace ApiBrnetEstoque.DTOs.Atendimentos
{
    public class AtendimentoDto
    {
        public int IdAtendimentos { get; set; }
        public TimeOnly? Hora { get; set; }
        public string? CodCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? Observacao { get; set; }
        public int ControleKmId { get; set; }
    }
}
