using Cepedi.BancoCentral.Cadastro.Compartilhado.Enums;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
public class ResultadoErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}
