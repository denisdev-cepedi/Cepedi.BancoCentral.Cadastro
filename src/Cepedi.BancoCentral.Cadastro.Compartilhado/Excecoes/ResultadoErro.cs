using Cepedi.BancoCentral.Cadastro.Shareable.Enums;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Excecoes;
public class ResultadoErro
{
    public string Titulo { get; set; } = default!;

    public string Descricao { get; set; } = default!;

    public ETipoErro Tipo { get; set; }
}
