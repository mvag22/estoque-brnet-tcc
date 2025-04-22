using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Models;

namespace ApiBrnetEstoque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<ChecklistVeiculo> ChecklistsVeiculo { get; set; }
        public DbSet<MaterialEstoque> MateriaisEstoque { get; set; }
        public DbSet<EquipamentoReserva> EquipamentosReserva { get; set; }
        public DbSet<ControleKm> ControlesKm { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }
        public DbSet<MovimentacaoMaterial> MovimentacoesMaterial { get; set; }
    }
}
