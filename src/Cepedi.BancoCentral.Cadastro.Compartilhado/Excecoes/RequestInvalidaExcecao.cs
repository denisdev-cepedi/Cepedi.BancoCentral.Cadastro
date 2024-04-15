namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
public class RequestInvalidaExcecao : ExcecaoAplicacao
{
    public RequestInvalidaExcecao(IDictionary<string, string[]> erros)
        : base(Enums.Cadastro.DadosInvalidos) =>
        Erros = erros.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}");

    public IEnumerable<string> Erros { get; }
}
