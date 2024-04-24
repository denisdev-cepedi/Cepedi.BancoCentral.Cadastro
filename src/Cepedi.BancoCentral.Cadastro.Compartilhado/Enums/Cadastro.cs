using Cepedi.BancoCentral.Cadastro.Shareable.Excecoes;

namespace Cepedi.BancoCentral.Cadastro.Shareable.Enums;
public class Cadastro
{
    public static readonly ResultadoErro Generico = new()
    {
        Titulo = "Ops ocorreu um erro no nosso sistema",
        Descricao = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static readonly ResultadoErro SemResultados = new()
    {
        Titulo = "Sua busca não obteve resultados",
        Descricao = "Tente buscar novamente",
        Tipo = ETipoErro.Alerta
    };

    public static ResultadoErro ErroGravacaoUsuario = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação do usuário. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro DadosInvalidos = new()
    {
        Titulo = "Dados inválidos",
        Descricao = "Os dados enviados na requisição são inválidos",
        Tipo = ETipoErro.Erro
    };

     public static ResultadoErro ErroGravacaoTipoRegistro = new()
    {
        Titulo = "Ocorreu um erro na gravação",
        Descricao = "Ocorreu um erro na gravação do tidpo de registro. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroDeletarTipoRegistro = new()
    {
        Titulo = "Ocorreu um erro ao deletar",
        Descricao = "Ocorreu um erro ao deletar o tipo de registro. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };

    public static ResultadoErro ErroLeituraTipoRegistro = new()
    {
        Titulo = "Ocorreu um erro na leitura",
        Descricao = "Ocorreu um erro na leitura do tipo de registro. Por favor tente novamente",
        Tipo = ETipoErro.Erro
    };
}
