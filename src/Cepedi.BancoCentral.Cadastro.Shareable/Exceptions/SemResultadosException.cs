using Cepedi.BancoCentral.Cadastro.Shareable.Enums;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Exceptions;
public class SemResultadosException : ApplicationException
{
    public SemResultadosException() : 
        base(BancoCentralMensagemErrors.SemResultados)
    {
    }
}
