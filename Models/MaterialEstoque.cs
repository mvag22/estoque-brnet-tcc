using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class MaterialEstoque
{
    public int IdMaterial { get; set; }

    public string Nome { get; set; } = null!;

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int Quantidade { get; set; }

    public virtual ICollection<MovimentacaoMaterial> MovimentacaoMaterials { get; set; } = new List<MovimentacaoMaterial>();
}
