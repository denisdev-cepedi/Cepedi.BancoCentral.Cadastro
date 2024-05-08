using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IEstadoCivilRepository
{
    Task<EstadoCivilEntity> CriarEstadoCivilAsync(EstadoCivilEntity estadoCivil);
    Task<EstadoCivilEntity> ObterEstadoCivilAsync(int id);
    Task<EstadoCivilEntity> AtualizarEstadoCivilAsync(EstadoCivilEntity estadoCivil);
    Task<EstadoCivilEntity> DeletarEstadoCivilAsync(EstadoCivilEntity estadoCivil);
    Task<List<EstadoCivilEntity>> GetEstadosCivilAsync();
}
