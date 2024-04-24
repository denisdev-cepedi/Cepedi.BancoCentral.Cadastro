namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class BancoEntity
{
    public int IdBanco { get; set; }
    public string? NomeFantasia { get; set; }
    public required string NomeReal { get; set; }
    public required string Cnpj { get; set; }
    public DateTime DataCriacao { get; set; }
}
