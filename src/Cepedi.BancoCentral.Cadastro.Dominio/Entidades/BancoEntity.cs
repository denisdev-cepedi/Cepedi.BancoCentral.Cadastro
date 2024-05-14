﻿namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class BancoEntity 
{
    public int IdBanco { get; set; }
    public string NomeReal { get; set; } = default!;
    public string NomeFantasia { get; set; } = default!;
    public string Cnpj { get; set; } = default!;
    public DateTime DataCriacao { get; set; }

}
