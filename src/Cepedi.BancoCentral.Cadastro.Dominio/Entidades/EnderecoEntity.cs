namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class EnderecoEntity
{
    public int IdEndereco { get; set; }
    public string Cep { get; set; } = default!;
    public string Logradouro { get; set; } = default!;
    public string Numero { get; set; } = default!;
    public string Bairro { get; set; } = default!;
    public string Cidade { get; set; } = default!;
    public string Estado { get; set; } = default!;
    public string Pais { get; set; } = default!;
    public int IdPessoa { get; set; }
    
    internal void Atualizar(string cep, string logradouro, string numero, string bairro, string cidade, string estado, string pais)
    {
        Cep = cep;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Pais = pais;
    }
}
