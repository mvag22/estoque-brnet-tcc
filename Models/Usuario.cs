using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Perfil { get; set; } = null!;

    public virtual ICollection<ChecklistVeiculo> ChecklistVeiculos { get; set; } = new List<ChecklistVeiculo>();

    public virtual ICollection<ControleKm> ControleKmUsuarioId1Navigations { get; set; } = new List<ControleKm>();

    public virtual ICollection<ControleKm> ControleKmUsuarioId2Navigations { get; set; } = new List<ControleKm>();

    public virtual ICollection<EquipamentoReserva> EquipamentoReservas { get; set; } = new List<EquipamentoReserva>();

    public virtual ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = new List<MovimentacaoEstoque>();
}
