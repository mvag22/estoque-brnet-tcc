using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class EquipamentoReserva
{
    public int IdEquipamento { get; set; }

    public string Mac { get; set; } = null!;

    public string? Status { get; set; }

    public int? CodCliente { get; set; }

    public string? Defeito { get; set; }

    public DateOnly DataPegou { get; set; }

    public string? Tipo { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
