namespace Cepedi.BancoCentral.Cadastro.Shareable.Excecoes;
public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(Enums.Cadastro.SemResultados)
    {
    }
}
