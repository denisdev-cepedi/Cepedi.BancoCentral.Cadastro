using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface INacionalidadeRepository
{
    Task<NacionalidadeEntity> CriarNacionalidadeAsync(NacionalidadeEntity nacionalidade);
    Task<NacionalidadeEntity> ObterNacionalidadeAsync(int id);
    Task<NacionalidadeEntity> AtualizarNacionalidadeAsync(NacionalidadeEntity nacionalidade);
    Task<NacionalidadeEntity> DeletarNacionalidadeAsync(NacionalidadeEntity nacionalidade);
    Task<List<NacionalidadeEntity>> GetNacionalidadesAsync();
}
