using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository
{
    public interface IPessoaRepository
    {
        Task<PessoaEntity> CriarPessoaAsync(PessoaEntity pessoa);
        Task<PessoaEntity> ObterPessoaAsync(int id);

        Task<PessoaEntity> AtualizarPessoaAsync(PessoaEntity pessoa);
        Task<PessoaEntity> DeletarPessoaAsync(int id);
        Task<List<PessoaEntity>> GetPessoasAsync();
    }

}
