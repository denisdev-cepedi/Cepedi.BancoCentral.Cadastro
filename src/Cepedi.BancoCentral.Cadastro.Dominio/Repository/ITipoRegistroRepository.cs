﻿using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface ITipoRegistroRepository
{
    Task<TipoRegistroEntity> CriarTipoRegistroAsync(TipoRegistroEntity TipoRegistro);
    Task<TipoRegistroEntity> ObterTipoRegistroAsync(int id);
    Task<List<TipoRegistroEntity>> ObterTipoRegistroAsync();

    Task<TipoRegistroEntity> AtualizarTipoRegistroAsync(TipoRegistroEntity TipoRegistro);

    Task<TipoRegistroEntity> DeletarTipoRegistroAsync(TipoRegistroEntity TipoRegistro);

}
