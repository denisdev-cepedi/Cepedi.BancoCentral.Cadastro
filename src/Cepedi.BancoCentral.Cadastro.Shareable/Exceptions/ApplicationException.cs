using Cepedi.Shareable.Exceptions;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Exceptions;
public class ApplicationException : Exception
{
    public ApplicationException(ResponseErro erro)
     : base(erro.Descricao) => ResponseErro = erro;

    public ResponseErro ResponseErro { get; set; }
}
