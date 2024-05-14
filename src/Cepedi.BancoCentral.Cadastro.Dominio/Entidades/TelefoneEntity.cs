namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TelefoneEntity
{
    public int IdTelefone { get; set; }
    public string NumeroTelefone { get; set; } = default!;
    public int IdPessoa { get; set; }
    
    internal void Atualizar(string numero)
    {
        NumeroTelefone = numero;
    }
}
