﻿namespace GestaoAutoEscola.API.Domain.Entities;

public class Veiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Cor { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public bool Status { get; set; }
    public int Kilometragem { get; set; }
    public DateTime DataUltimaManutencao { get; set; }
    public int TipoVeiculoId { get; set; }
    public virtual List<Aula> Aulas { get; set; } = new List<Aula>();
    public virtual List<Instrutor> Instrutores { get; set; } = new List<Instrutor>();
    public virtual TipoVeiculo TipoVeiculo { get; set; } = default!;
}
