namespace Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
// public record RegistroTransacaoPessoaTipoTransacaoDto (int IdRegistro, string NomeTipoRegistro, string NomePessoa, double Valor);
public class RegistroTransacaoPessoaTipoTransacaoDto
{
    public int IdRegistro { get; set; }
    public string NomeTipoRegistro { get; set; }
    public string NomePessoa { get; set; }
    public double Valor { get; set; }
    public RegistroTransacaoPessoaTipoTransacaoDto()
    {
    }
    public RegistroTransacaoPessoaTipoTransacaoDto(int idRegistro, string nomeTipoRegistro, string nomePessoa, double valor)
    {
        IdRegistro = idRegistro;
        NomeTipoRegistro = nomeTipoRegistro;
        NomePessoa = nomePessoa;
        Valor = valor;
    }
}
