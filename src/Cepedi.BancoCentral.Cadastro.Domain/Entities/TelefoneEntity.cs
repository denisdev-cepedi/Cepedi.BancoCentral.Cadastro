namespace Cepedi.BancoCentral.Cadastro.Domain;

public class TelefoneEntity
{
    public int IdTelefone { get; set; }
    public int Ddd { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public int IdPessoa { get; set; }
}
