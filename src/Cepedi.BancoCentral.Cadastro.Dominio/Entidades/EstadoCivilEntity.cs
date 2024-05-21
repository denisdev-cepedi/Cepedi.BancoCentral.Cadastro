namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class EstadoCivilEntity
{
    public int IdEstadoCivil { get; set; }
    public string NomeEstadoCivil { get; set; } = default!;
    internal void Atualizar(string nomeEstadoCivil)
    {
        NomeEstadoCivil = nomeEstadoCivil;
    }
}

