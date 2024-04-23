namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class EnderecoEntity
{
    public int IdEndereco { get; set; }
    public string Cep { get; set; } = default!;
    public string Logradouro { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public int IdPessoa { get; set; }
}
