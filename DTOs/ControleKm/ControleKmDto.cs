using System;

namespace ApiBrnetEstoque.DTOs.ControleKm
{
    public class ControleKmDto
    {
        public int IdKm { get; set; }
        public DateOnly Data { get; set; }
        public int VeiculoId { get; set; }
        public int UsuarioId1 { get; set; }
        public int? UsuarioId2 { get; set; }
    }
}
