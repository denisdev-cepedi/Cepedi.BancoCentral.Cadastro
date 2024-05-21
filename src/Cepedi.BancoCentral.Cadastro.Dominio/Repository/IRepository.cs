namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IRepository<T> where T : class
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    IRepository<T> Repository<T>()
        where T: class;

}
