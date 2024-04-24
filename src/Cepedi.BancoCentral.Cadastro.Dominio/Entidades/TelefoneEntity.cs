namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TelefoneEntity
{
    public int IdTelefone { get; set; }
    public int Ddd { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public int IdPessoa { get; set; }
}
