namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class NacionalidadeEntity
{
    public int IdNacionalidade { get; set; }
    public string NomeNacionalidade { get; set; } = default!;
    internal void Atualizar(string nomeNacionalidade)
    {
        NomeNacionalidade = nomeNacionalidade;
    }
}
