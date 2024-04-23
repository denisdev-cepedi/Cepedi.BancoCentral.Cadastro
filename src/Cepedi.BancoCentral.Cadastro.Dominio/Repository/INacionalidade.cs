using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface INacionalidade
{
    Task<NacionalidadeEntity> CriarNacionalidadeAsync(NacionalidadeEntity nacionalidade);
    Task<NacionalidadeEntity> ObterNacionalidadeAsync(int id);
    Task<NacionalidadeEntity> AtualizarNacionalidadeAsync(NacionalidadeEntity nacionalidade);
    Task<NacionalidadeEntity> DeletarNacionalidadeAsync(int id);
    Task<List<NacionalidadeEntity>> GetNacionalidadesAsync();    
}
