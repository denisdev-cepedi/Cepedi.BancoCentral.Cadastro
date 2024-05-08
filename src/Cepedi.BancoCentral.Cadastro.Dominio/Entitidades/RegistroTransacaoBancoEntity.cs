﻿namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class RegistroTransacaoBancoEntity
{
    public int IdRegistro { get; set; }
    public DateTime DataRegistro { get; set; }
    public int IdTipoRegistro { get; set; }
    public required TipoRegistroEntity TipoRegistro { get; set; } 
    public int IdPessoa { get; set; }
    public required PessoaEntity Pessoa { get; set; } 
    public int IdBanco { get; set; }
    public required BancoEntity Banco { get; set; }
    public double Valor { get; set; }


}
