using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IEnderecoRepository
{
    Task<EnderecoEntity> CriarEnderecoAsync(EnderecoEntity endereco);
    Task<EnderecoEntity> ObterEnderecoAsync(int id);
    Task<EnderecoEntity> AtualizarEnderecoAsync(EnderecoEntity endereco);
    Task<EnderecoEntity> DeletarEnderecoAsync(EnderecoEntity endereco);
    Task<List<EnderecoEntity>> GetEnderecosAsync();
}
