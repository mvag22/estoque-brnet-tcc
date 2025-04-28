using System;

namespace ApiBrnetEstoque.DTOs.EquipamentoReserva
{
    public class EquipamentoReservaDto
    {
        public int IdEquipamento { get; set; }
        public string Mac { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Status { get; set; }
        public int? CodCliente { get; set; }
        public string? Defeito { get; set; }
        public DateOnly DataPegou { get; set; }
        public int UsuarioId { get; set; }
    }
}
