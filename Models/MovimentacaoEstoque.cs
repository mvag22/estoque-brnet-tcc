using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class MovimentacaoEstoque
{
    public int IdMovimentacao { get; set; }

    public DateTime DataMovimentacao { get; set; }

    public string? Observacao { get; set; }

    public string? TipoMovimentacao { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<MovimentacaoMaterial> MovimentacaoMaterials { get; set; } = new List<MovimentacaoMaterial>();

    public virtual Usuario Usuario { get; set; } = null!;
}
