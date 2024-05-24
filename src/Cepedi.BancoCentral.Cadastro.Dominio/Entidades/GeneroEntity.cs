namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class GeneroEntity
{
    public int IdGenero { get; set; }
    public string NomeGenero { get; set; } = default!;
    
    internal void Atualizar(string nomeGenero)
    {
        NomeGenero = nomeGenero;
    }
}
