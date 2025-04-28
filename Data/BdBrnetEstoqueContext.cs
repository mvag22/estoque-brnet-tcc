using System;
using System.Collections.Generic;
using ApiBrnetEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApiBrnetEstoque.Data;

public partial class BdBrnetEstoqueContext : DbContext
{
    public BdBrnetEstoqueContext()
    {
    }

    public BdBrnetEstoqueContext(DbContextOptions<BdBrnetEstoqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendimento> Atendimentos { get; set; }

    public virtual DbSet<ChecklistVeiculo> ChecklistVeiculos { get; set; }

    public virtual DbSet<ControleKm> ControleKms { get; set; }

    public virtual DbSet<EquipamentoReserva> EquipamentoReservas { get; set; }

    public virtual DbSet<MaterialEstoque> MaterialEstoques { get; set; }

    public virtual DbSet<MovimentacaoEstoque> MovimentacaoEstoques { get; set; }

    public virtual DbSet<MovimentacaoMaterial> MovimentacaoMaterials { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VEstoqueGeral> VEstoqueGerals { get; set; }

    public virtual DbSet<VRelatorioChecklist> VRelatorioChecklists { get; set; }

    public virtual DbSet<VRelatorioKm> VRelatorioKms { get; set; }

    public virtual DbSet<VRelatorioMovimentacao> VRelatorioMovimentacaos { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=bd_brnet_estoque;user=root", ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Atendimento>(entity =>
        {
            entity.HasKey(e => e.IdAtendimentos).HasName("PRIMARY");

            entity
                .ToTable("atendimentos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ControleKmId, "idx_atendimentos_controle_km");

            entity.Property(e => e.IdAtendimentos)
                .HasColumnType("int(11)")
                .HasColumnName("id_atendimentos");
            entity.Property(e => e.CodCliente)
                .HasMaxLength(45)
                .HasColumnName("cod_cliente");
            entity.Property(e => e.ControleKmId)
                .HasColumnType("int(11)")
                .HasColumnName("controle_km_id");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(100)
                .HasColumnName("nome_cliente");
            entity.Property(e => e.Observacao)
                .HasColumnType("text")
                .HasColumnName("observacao");

            entity.HasOne(d => d.ControleKm).WithMany(p => p.Atendimentos)
                .HasForeignKey(d => d.ControleKmId)
                .HasConstraintName("fk_atendimentos_controle_km");
        });

        modelBuilder.Entity<ChecklistVeiculo>(entity =>
        {
            entity.HasKey(e => e.IdChecklist).HasName("PRIMARY");

            entity
                .ToTable("checklist_veiculo")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UsuarioId, "idx_checklist_veiculo_usuario");

            entity.HasIndex(e => e.VeiculoId, "idx_checklist_veiculo_veiculo");

            entity.Property(e => e.IdChecklist)
                .HasColumnType("int(11)")
                .HasColumnName("id_checklist");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.KmAtual)
                .HasColumnType("int(11)")
                .HasColumnName("km_atual");
            entity.Property(e => e.KmTrocaOleo)
                .HasColumnType("int(11)")
                .HasColumnName("km_troca_oleo");
            entity.Property(e => e.ObsAguaRadiador)
                .HasMaxLength(80)
                .HasColumnName("obs_agua_radiador");
            entity.Property(e => e.ObsBuzina)
                .HasMaxLength(80)
                .HasColumnName("obs_buzina");
            entity.Property(e => e.ObsCones)
                .HasMaxLength(80)
                .HasColumnName("obs_cones");
            entity.Property(e => e.ObsEscadas)
                .HasMaxLength(80)
                .HasColumnName("obs_escadas");
            entity.Property(e => e.ObsEspelhoRetrovisor)
                .HasMaxLength(80)
                .HasColumnName("obs_espelho_retrovisor");
            entity.Property(e => e.ObsEstepe)
                .HasMaxLength(80)
                .HasColumnName("obs_estepe");
            entity.Property(e => e.ObsFarolFaroletes)
                .HasMaxLength(80)
                .HasColumnName("obs_farol_faroletes");
            entity.Property(e => e.ObsFreioEstacionamento)
                .HasMaxLength(80)
                .HasColumnName("obs_freio_estacionamento");
            entity.Property(e => e.ObsLimpadorParabrisas)
                .HasMaxLength(80)
                .HasColumnName("obs_limpador_parabrisas");
            entity.Property(e => e.ObsLuzesRe)
                .HasMaxLength(80)
                .HasColumnName("obs_luzes_re");
            entity.Property(e => e.ObsMotorLimpo)
                .HasMaxLength(80)
                .HasColumnName("obs_motor_limpo");
            entity.Property(e => e.ObsOleoFreio)
                .HasMaxLength(80)
                .HasColumnName("obs_oleo_freio");
            entity.Property(e => e.ObsPneus)
                .HasMaxLength(80)
                .HasColumnName("obs_pneus");
            entity.Property(e => e.ObsPortas)
                .HasMaxLength(80)
                .HasColumnName("obs_portas");
            entity.Property(e => e.ObsSetas)
                .HasMaxLength(80)
                .HasColumnName("obs_setas");
            entity.Property(e => e.ObsTriangulo)
                .HasMaxLength(80)
                .HasColumnName("obs_triangulo");
            entity.Property(e => e.ObsVidroParabrisa)
                .HasMaxLength(80)
                .HasColumnName("obs_vidro_parabrisa");
            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");
            entity.Property(e => e.VeiculoId)
                .HasColumnType("int(11)")
                .HasColumnName("veiculo_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ChecklistVeiculos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_checklist_veiculo_usuario");

            entity.HasOne(d => d.Veiculo).WithMany(p => p.ChecklistVeiculos)
                .HasForeignKey(d => d.VeiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_checklist_veiculo_veiculo");
        });

        modelBuilder.Entity<ControleKm>(entity =>
        {
            entity.HasKey(e => e.IdKm).HasName("PRIMARY");

            entity
                .ToTable("controle_km")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UsuarioId1, "idx_controle_km_usuario1");

            entity.HasIndex(e => e.UsuarioId2, "idx_controle_km_usuario2");

            entity.HasIndex(e => e.VeiculoId, "idx_controle_km_veiculo");

            entity.Property(e => e.IdKm)
                .HasColumnType("int(11)")
                .HasColumnName("id_km");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.UsuarioId1)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id1");
            entity.Property(e => e.UsuarioId2)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id2");
            entity.Property(e => e.VeiculoId)
                .HasColumnType("int(11)")
                .HasColumnName("veiculo_id");

            entity.HasOne(d => d.UsuarioId1Navigation).WithMany(p => p.ControleKmUsuarioId1Navigations)
                .HasForeignKey(d => d.UsuarioId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controle_km_usuario1");

            entity.HasOne(d => d.UsuarioId2Navigation).WithMany(p => p.ControleKmUsuarioId2Navigations)
                .HasForeignKey(d => d.UsuarioId2)
                .HasConstraintName("fk_controle_km_usuario2");

            entity.HasOne(d => d.Veiculo).WithMany(p => p.ControleKms)
                .HasForeignKey(d => d.VeiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controle_km_veiculo");
        });

        modelBuilder.Entity<EquipamentoReserva>(entity =>
        {
            entity.HasKey(e => e.IdEquipamento).HasName("PRIMARY");

            entity
                .ToTable("equipamento_reserva")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UsuarioId, "idx_equipamento_reserva_usuario");

            entity.Property(e => e.IdEquipamento)
                .HasColumnType("int(11)")
                .HasColumnName("id_equipamento");
            entity.Property(e => e.CodCliente)
                .HasColumnType("int(11)")
                .HasColumnName("cod_cliente");
            entity.Property(e => e.DataPegou).HasColumnName("data_pegou");
            entity.Property(e => e.Defeito)
                .HasMaxLength(150)
                .HasColumnName("defeito");
            entity.Property(e => e.Mac)
                .HasMaxLength(12)
                .HasColumnName("mac");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.EquipamentoReservas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipamento_reserva_usuario");
        });

        modelBuilder.Entity<MaterialEstoque>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PRIMARY");

            entity
                .ToTable("material_estoque")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdMaterial)
                .HasColumnType("int(11)")
                .HasColumnName("id_material");
            entity.Property(e => e.Marca)
                .HasMaxLength(45)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(45)
                .HasColumnName("modelo");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Quantidade)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade");
        });

        modelBuilder.Entity<MovimentacaoEstoque>(entity =>
        {
            entity.HasKey(e => e.IdMovimentacao).HasName("PRIMARY");

            entity
                .ToTable("movimentacao_estoque")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.UsuarioId, "idx_movimentacao_estoque_usuario");

            entity.Property(e => e.IdMovimentacao)
                .HasColumnType("int(11)")
                .HasColumnName("id_movimentacao");
            entity.Property(e => e.DataMovimentacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("data_movimentacao");
            entity.Property(e => e.Observacao)
                .HasMaxLength(100)
                .HasColumnName("observacao");
            entity.Property(e => e.TipoMovimentacao)
                .HasColumnType("enum('entrada','saida_manual','retirada_tecnico')")
                .HasColumnName("tipo_movimentacao");
            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MovimentacaoEstoques)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimentacao_estoque_usuario");
        });

        modelBuilder.Entity<MovimentacaoMaterial>(entity =>
        {
            entity.HasKey(e => e.IdMovMaterial).HasName("PRIMARY");

            entity
                .ToTable("movimentacao_material")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.MaterialEstoqueId, "idx_mov_material_estoque");

            entity.HasIndex(e => e.MovimentacaoEstoqueId, "idx_mov_material_movimentacao");

            entity.Property(e => e.IdMovMaterial)
                .HasColumnType("int(11)")
                .HasColumnName("id_mov_material");
            entity.Property(e => e.MaterialEstoqueId)
                .HasColumnType("int(11)")
                .HasColumnName("material_estoque_id");
            entity.Property(e => e.MovimentacaoEstoqueId)
                .HasColumnType("int(11)")
                .HasColumnName("movimentacao_estoque_id");
            entity.Property(e => e.Quantidade)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade");

            entity.HasOne(d => d.MaterialEstoque).WithMany(p => p.MovimentacaoMaterials)
                .HasForeignKey(d => d.MaterialEstoqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimentacao_material_estoque");

            entity.HasOne(d => d.MovimentacaoEstoque).WithMany(p => p.MovimentacaoMaterials)
                .HasForeignKey(d => d.MovimentacaoEstoqueId)
                .HasConstraintName("fk_movimentacao_material_movimentacao");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity
                .ToTable("usuario")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Usuario1, "usuario_UNIQUE").IsUnique();

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("id_usuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Perfil)
                .HasColumnType("enum('admin_estoque','tecnico')")
                .HasColumnName("perfil");
            entity.Property(e => e.Senha)
                .HasMaxLength(80)
                .HasColumnName("senha");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<VEstoqueGeral>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_estoque_geral");

            entity.Property(e => e.IdMaterial)
                .HasColumnType("int(11)")
                .HasColumnName("id_material");
            entity.Property(e => e.Marca)
                .HasMaxLength(45)
                .HasColumnName("marca")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Modelo)
                .HasMaxLength(45)
                .HasColumnName("modelo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Quantidade)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade");
        });

        modelBuilder.Entity<VRelatorioChecklist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_relatorio_checklist");

            entity.Property(e => e.DataChecklist).HasColumnName("data_checklist");
            entity.Property(e => e.IdChecklist)
                .HasColumnType("int(11)")
                .HasColumnName("id_checklist");
            entity.Property(e => e.KmAtual)
                .HasColumnType("int(11)")
                .HasColumnName("km_atual");
            entity.Property(e => e.KmTrocaOleo)
                .HasColumnType("int(11)")
                .HasColumnName("km_troca_oleo");
            entity.Property(e => e.ModeloVeiculo)
                .HasMaxLength(100)
                .HasColumnName("modelo_veiculo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsAguaRadiador)
                .HasMaxLength(80)
                .HasColumnName("obs_agua_radiador")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsBuzina)
                .HasMaxLength(80)
                .HasColumnName("obs_buzina")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsCones)
                .HasMaxLength(80)
                .HasColumnName("obs_cones")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsEscadas)
                .HasMaxLength(80)
                .HasColumnName("obs_escadas")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsEspelhoRetrovisor)
                .HasMaxLength(80)
                .HasColumnName("obs_espelho_retrovisor")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsEstepe)
                .HasMaxLength(80)
                .HasColumnName("obs_estepe")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsFarolFaroletes)
                .HasMaxLength(80)
                .HasColumnName("obs_farol_faroletes")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsFreioEstacionamento)
                .HasMaxLength(80)
                .HasColumnName("obs_freio_estacionamento")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsLimpadorParabrisas)
                .HasMaxLength(80)
                .HasColumnName("obs_limpador_parabrisas")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsLuzesRe)
                .HasMaxLength(80)
                .HasColumnName("obs_luzes_re")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsMotorLimpo)
                .HasMaxLength(80)
                .HasColumnName("obs_motor_limpo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsOleoFreio)
                .HasMaxLength(80)
                .HasColumnName("obs_oleo_freio")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsPneus)
                .HasMaxLength(80)
                .HasColumnName("obs_pneus")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsPortas)
                .HasMaxLength(80)
                .HasColumnName("obs_portas")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsSetas)
                .HasMaxLength(80)
                .HasColumnName("obs_setas")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsTriangulo)
                .HasMaxLength(80)
                .HasColumnName("obs_triangulo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsVidroParabrisa)
                .HasMaxLength(80)
                .HasColumnName("obs_vidro_parabrisa")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PlacaVeiculo)
                .HasMaxLength(10)
                .HasColumnName("placa_veiculo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Tecnico)
                .HasMaxLength(100)
                .HasColumnName("tecnico")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<VRelatorioKm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_relatorio_km");

            entity.Property(e => e.CodCliente)
                .HasMaxLength(45)
                .HasColumnName("cod_cliente")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.DataControle).HasColumnName("data_controle");
            entity.Property(e => e.HoraAtendimento)
                .HasColumnType("time")
                .HasColumnName("hora_atendimento");
            entity.Property(e => e.IdKm)
                .HasColumnType("int(11)")
                .HasColumnName("id_km");
            entity.Property(e => e.ModeloVeiculo)
                .HasMaxLength(100)
                .HasColumnName("modelo_veiculo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(100)
                .HasColumnName("nome_cliente")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsAtendimento)
                .HasColumnType("text")
                .HasColumnName("obs_atendimento")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.PlacaVeiculo)
                .HasMaxLength(10)
                .HasColumnName("placa_veiculo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Tecnico1)
                .HasMaxLength(100)
                .HasColumnName("tecnico1")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Tecnico2)
                .HasMaxLength(100)
                .HasColumnName("tecnico2")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<VRelatorioMovimentacao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_relatorio_movimentacao");

            entity.Property(e => e.DataMov)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("data_mov");
            entity.Property(e => e.IdMaterial)
                .HasColumnType("int(11)")
                .HasColumnName("id_material");
            entity.Property(e => e.IdMov)
                .HasColumnType("int(11)")
                .HasColumnName("id_mov");
            entity.Property(e => e.MarcaMaterial)
                .HasMaxLength(45)
                .HasColumnName("marca_material")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ModeloMaterial)
                .HasMaxLength(45)
                .HasColumnName("modelo_material")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.NomeMaterial)
                .HasMaxLength(100)
                .HasColumnName("nome_material")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ObsMov)
                .HasMaxLength(100)
                .HasColumnName("obs_mov")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.QuantidadeMov)
                .HasColumnType("int(11)")
                .HasColumnName("quantidade_mov");
            entity.Property(e => e.TipoMovimentacao)
                .HasColumnType("enum('entrada','saida_manual','retirada_tecnico')")
                .HasColumnName("tipo_movimentacao")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .HasColumnName("usuario")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.IdVeiculo).HasName("PRIMARY");

            entity
                .ToTable("veiculo")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Placa, "placa_UNIQUE").IsUnique();

            entity.Property(e => e.IdVeiculo)
                .HasColumnType("int(11)")
                .HasColumnName("id_veiculo");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .HasColumnName("placa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
