﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

public class TipoRegistroEntity
{
    public int IdTipoRegistro { get; set; }
    public string NomeTipo { get; set; } = default!;

    internal void AtualizarTipoRegistroAsync(AtualizarTipoRegistroRequest tipoAtualizado)
    {
        NomeTipo = tipoAtualizado.NomeTipo;
    }

}
