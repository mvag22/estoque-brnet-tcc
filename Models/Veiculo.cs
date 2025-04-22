namespace ApiBrnetEstoque.Models
{
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;

        // Relacionamentos
        public ICollection<ChecklistVeiculo>? Checklists { get; set; }
        public ICollection<ControleKm>? ControlesKm { get; set; }
    }
}
