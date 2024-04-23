namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TipoPix
{
    public int IdTipoPix {get; set;}
    public string NomeTipo {get; set;} = default!;
    public List<PixEntity>? Pixs { get; set; }
}
