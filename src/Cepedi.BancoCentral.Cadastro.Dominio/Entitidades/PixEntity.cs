namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class PixEntity
{
    public int IdPix { get; set; }
    public string ChavePix {get; set;} = default!;
    public string Agencia {get; set;} = default!;
    public string Conta {get; set;} = default!;
    public string Instituicao {get; set;} = default!;
    public int IdTipoPix{get; set;}
    public TipoPix? TipoPix {get; set;}

    internal void Atualizar(string chavePix){
        this.ChavePix = chavePix;
    }


}
