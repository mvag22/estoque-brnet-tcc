using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class VRelatorioKm
{
    public int IdKm { get; set; }

    public DateOnly DataControle { get; set; }

    public string PlacaVeiculo { get; set; } = null!;

    public string ModeloVeiculo { get; set; } = null!;

    public string Tecnico1 { get; set; } = null!;

    public string? Tecnico2 { get; set; }

    public TimeOnly? HoraAtendimento { get; set; }

    public string? CodCliente { get; set; }

    public string? NomeCliente { get; set; }

    public string? ObsAtendimento { get; set; }
}
