namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;

public record CriarRegistroTransacaoBancoResponse(int IdTransacao,DateTime DataRegistro, string NomeTipoRegistro, string NomePessoa, string NomeBanco);
