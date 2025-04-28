using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class VEstoqueGeral
{
    public int IdMaterial { get; set; }

    public string Nome { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int Quantidade { get; set; }
}
