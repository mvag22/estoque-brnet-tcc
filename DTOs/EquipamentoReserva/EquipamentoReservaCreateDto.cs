using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.EquipamentoReserva
{
    public class EquipamentoReservaCreateDto
    {
        [Required, StringLength(12)]
        public string Mac { get; set; } = null!;

        [StringLength(45)]
        public string? Tipo { get; set; }

        [StringLength(45)]
        public string? Status { get; set; }

        public int? CodCliente { get; set; }

        [StringLength(150)]
        public string? Defeito { get; set; }

        [Required]
        public DateOnly DataPegou { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}
