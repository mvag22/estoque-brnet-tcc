using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class MovimentacaoMaterial
{
    public int IdMovMaterial { get; set; }

    public int MovimentacaoEstoqueId { get; set; }

    public int MaterialEstoqueId { get; set; }

    public int Quantidade { get; set; }

    public virtual MaterialEstoque MaterialEstoque { get; set; } = null!;

    public virtual MovimentacaoEstoque MovimentacaoEstoque { get; set; } = null!;
}
