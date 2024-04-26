using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Repository;

public interface IRegistroTransacaoBancoRepository
{
    Task<RegistroTransacaoBancoEntity> CriarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco);
    Task<RegistroTransacaoBancoEntity> ObterRegistroTransacaoBancoAsync(int id);
    Task<List<RegistroTransacaoBancoEntity>> ObterRegistroTransacaoBancoAsync();
    Task<RegistroTransacaoBancoEntity> AtualizarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco);
    Task<RegistroTransacaoBancoEntity> DeletarRegistroTransacaoBancoAsync(RegistroTransacaoBancoEntity registroTransacaoBanco);

    Task<PessoaEntity> ObterRegistroTransacaoBancoPorIdPessoaAsync(int idPessoa);
    Task<BancoEntity> ObterRegistroTransacaoBancoPorIdBancoAsync(int idBanco);

}
