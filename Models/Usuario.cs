namespace ApiBrnetEstoque.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string UsuarioLogin { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty; // "admin_estoque" ou "tecnico"

        // Relacionamentos
        public ICollection<ChecklistVeiculo>? Checklists { get; set; }
        public ICollection<EquipamentoReserva>? Equipamentos { get; set; }
        public ICollection<MovimentacaoEstoque>? Movimentacoes { get; set; }
    }
}
