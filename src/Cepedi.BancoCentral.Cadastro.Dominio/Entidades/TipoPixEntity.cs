﻿namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TipoPixEntity
{
    public int IdTipoPix {get; set;}
    public string TipoPix {get; set;} = default!;
    public List<PixEntity>? Pixs { get; set; } = new List<PixEntity>();

    internal void Atualizar(string tipoPix){
        TipoPix = tipoPix;
    }
}
