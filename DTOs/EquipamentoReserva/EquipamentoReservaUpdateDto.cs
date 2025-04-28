using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.EquipamentoReserva
{
    public class EquipamentoReservaUpdateDto
    {
        [StringLength(12)]
        public string? Mac { get; set; }

        [StringLength(45)]
        public string? Tipo { get; set; }

        [StringLength(45)]
        public string? Status { get; set; }

        public int? CodCliente { get; set; }

        [StringLength(150)]
        public string? Defeito { get; set; }

        public DateOnly? DataPegou { get; set; }

        public int? UsuarioId { get; set; }
    }
}
