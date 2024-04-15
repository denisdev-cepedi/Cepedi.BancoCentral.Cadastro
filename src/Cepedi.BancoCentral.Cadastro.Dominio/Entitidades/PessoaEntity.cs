namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
public class PessoaEntity
{
    public int IdPessoa { get; set; }

    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;
    public int Genero { get; set; } = default!;
    public int EstadoCivil { get; set; } = default!;
    public string Nacionalidade { get; set; } = default!;
    public List<TelefoneEntity> Telefones { get; set; } = new List<TelefoneEntity>();
    public List<EmailEntity> Emails { get; set; } = new List<EmailEntity>();
    public List<EnderecoEntity> Enderecos { get; set; } = new List<EnderecoEntity>();
    //public List<PixEntity> Pix { get; set; } = new List<PixEntity>();

    internal void Atualizar(string nome)
    {
        Nome = nome;
    }
}
