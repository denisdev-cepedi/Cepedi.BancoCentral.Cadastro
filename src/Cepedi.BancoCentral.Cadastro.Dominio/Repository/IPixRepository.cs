using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IPixRepository
{
    Task<PixEntity> CriarPixAsync(PixEntity pix);
    Task<PixEntity> ObterPixAsync(int id);
    Task<PixEntity> AtualizarPixAsync(PixEntity pix);
    Task<PixEntity> DeletarPixAsync(int id);
    Task<List<PixEntity>> GetPixsAsync();    
}
