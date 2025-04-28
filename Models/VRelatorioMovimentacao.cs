using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class VRelatorioMovimentacao
{
    public int IdMov { get; set; }

    public DateTime DataMov { get; set; }

    public string? TipoMovimentacao { get; set; }

    public string Usuario { get; set; } = null!;

    public int IdMaterial { get; set; }

    public string NomeMaterial { get; set; } = null!;

    public string? MarcaMaterial { get; set; }

    public string? ModeloMaterial { get; set; }

    public int QuantidadeMov { get; set; }

    public string? ObsMov { get; set; }
}
