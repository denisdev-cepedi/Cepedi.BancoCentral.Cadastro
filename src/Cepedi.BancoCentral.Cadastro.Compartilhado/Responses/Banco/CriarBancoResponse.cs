namespace Cepedi.BancoCentral.Cadastro.Shareable.Responses;

public record CriarBancoResponse(
    int idBanco,
    string nomeFantasia,
    string nomeReal,
    string cnpj,
    DateTime dataCriacao
)
{
    public CriarBancoResponse(int bancoIdBanco, string bancoNomeReal, string bancoCnpj, DateTime bancoDataCriacao) : this(default, default!, default!, default!, default)
    {
        idBanco = bancoIdBanco;
        nomeReal = bancoNomeReal;
        cnpj = bancoCnpj;
        dataCriacao = bancoDataCriacao;
    }
}
