using Cepedi.BancoCentral.Cadastro.Domain.Entities;

namespace Cepedi.BancoCentral.Cadastro.Domain.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> ObterUsuarioAsync(int id);

    Task<UsuarioEntity> AtualizarUsuarioAsync(UsuarioEntity usuario);
}
