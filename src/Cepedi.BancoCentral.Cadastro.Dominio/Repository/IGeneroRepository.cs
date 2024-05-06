using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IGeneroRepository
{
    Task<GeneroEntity> CriarGeneroAsync(GeneroEntity genero);
    Task<GeneroEntity> ObterGeneroAsync(int id);
    Task<GeneroEntity> AtualizarGeneroAsync(GeneroEntity genero);
    Task<GeneroEntity> DeletarGeneroAsync(GeneroEntity genero);
    Task<List<GeneroEntity>> GetGenerosAsync();
}
