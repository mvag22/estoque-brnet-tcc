using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBrnetEstoque.DTOs.Checklist
{
    public class ChecklistVeiculoUpdateDto
    {
        [Required] public DateOnly Data { get; set; }
        [Required] public int KmAtual { get; set; }
        public int? KmTrocaOleo { get; set; }
        [Required] public int UsuarioId { get; set; }
        [Required] public int VeiculoId { get; set; }

        public string? ObsOleoFreio { get; set; }
        public string? ObsAguaRadiador { get; set; }
        public string? ObsBuzina { get; set; }
        public string? ObsEspelhoRetrovisor { get; set; }
        public string? ObsTriangulo { get; set; }
        public string? ObsFreioEstacionamento { get; set; }
        public string? ObsEstepe { get; set; }
        public string? ObsVidroParabrisa { get; set; }
        public string? ObsPortas { get; set; }
        public string? ObsPneus { get; set; }
        public string? ObsFarolFaroletes { get; set; }
        public string? ObsLimpadorParabrisas { get; set; }
        public string? ObsSetas { get; set; }
        public string? ObsLuzesRe { get; set; }
        public string? ObsMotorLimpo { get; set; }
        public string? ObsCones { get; set; }
        public string? ObsEscadas { get; set; }
    }
}
