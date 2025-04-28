﻿using System;
using System.Collections.Generic;

namespace ApiBrnetEstoque.Models;

public partial class VRelatorioChecklist
{
    public int IdChecklist { get; set; }

    public DateOnly DataChecklist { get; set; }

    public string PlacaVeiculo { get; set; } = null!;

    public string ModeloVeiculo { get; set; } = null!;

    public string Tecnico { get; set; } = null!;

    public int KmAtual { get; set; }

    public int? KmTrocaOleo { get; set; }

    public string? ObsOleoFreio { get; set; }

    public string? ObsAguaRadiador { get; set; }

    public string? ObsBuzina { get; set; }

    public string? ObsEspelhoRetrovisor { get; set; }

    public string? ObsTriangulo { get; set; }

    public string? ObsFreioEstacionamento { get; set; }

    public string? ObsEstepe { get; set; }

    public string? ObsVidroParabrisa { get; set; }

    public string? ObsPortas { get; set; }

    public string? ObsPneus { get; set; }

    public string? ObsFarolFaroletes { get; set; }

    public string? ObsLimpadorParabrisas { get; set; }

    public string? ObsSetas { get; set; }

    public string? ObsLuzesRe { get; set; }

    public string? ObsMotorLimpo { get; set; }

    public string? ObsCones { get; set; }

    public string? ObsEscadas { get; set; }
}
