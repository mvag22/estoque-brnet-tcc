using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Atendimentos
{
    public class AtendimentoUpdateDto
    {
        [Required]
        public TimeOnly Hora { get; set; }

        public string? CodCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? Observacao { get; set; }
    }
}
