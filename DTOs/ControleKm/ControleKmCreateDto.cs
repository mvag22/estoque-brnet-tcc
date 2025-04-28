using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.ControleKm
{
    public class ControleKmCreateDto
    {
        [Required] public DateOnly Data { get; set; }
        [Required] public int VeiculoId { get; set; }
        [Required] public int UsuarioId1 { get; set; }
        public int? UsuarioId2 { get; set; }
    }
}
