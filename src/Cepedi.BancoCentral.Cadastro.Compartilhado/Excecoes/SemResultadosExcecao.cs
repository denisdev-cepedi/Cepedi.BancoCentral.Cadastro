namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
public class SemResultadosExcecao : ExcecaoAplicacao
{
    public SemResultadosExcecao() : 
        base(Enums.Cadastro.SemResultados)
    {
    }
}
