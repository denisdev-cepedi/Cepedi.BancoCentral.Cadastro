namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IRepository<T> where T : class
{
    Task<T> AdicionarAsync(T entidade, CancellationToken cancellationToken);

    T Atualizar(T entidade);

}
