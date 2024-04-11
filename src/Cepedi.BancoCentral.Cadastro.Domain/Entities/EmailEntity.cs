namespace Cepedi.BancoCentral.Cadastro.Domain;

public class EmailEntity
{
    public int IdEmail { get; set; }
    public string EnderecoEmail { get; set; } = default!;
    public int IdPessoa { get; set; }
}
