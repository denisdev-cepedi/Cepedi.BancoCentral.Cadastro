namespace Cepedi.BancoCentral.Cadastro.Domain;

public class EnderecoEntity
{
    public int IdEndereco { get; set; }
    public string Cep { get; set; } = default!;
    public string Rua { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public int IdPessoa { get; set; }
}
