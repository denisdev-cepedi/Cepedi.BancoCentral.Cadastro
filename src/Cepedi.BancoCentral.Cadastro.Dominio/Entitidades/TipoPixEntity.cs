using System.ComponentModel.DataAnnotations;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TipoPixEntity
{
    [Key]
    public int IdTipoPix {get; set;}
    public string NomeTipo {get; set;} = default!;
    public List<PixEntity>? Pixs { get; set; }

    internal void Atualizar(string nomeTipo){
        this.NomeTipo = nomeTipo;
    }
}
