namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class EmailEntity
{
    public int IdEmail { get; set; }
    public string EnderecoEmail { get; set; } = default!;
    public int IdPessoa { get; set; }
    
    internal void Atualizar(string endereco)
    {
        EnderecoEmail = endereco;
    }
}
