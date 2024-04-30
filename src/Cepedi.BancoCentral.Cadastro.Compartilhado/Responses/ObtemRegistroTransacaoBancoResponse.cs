namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
public record ObtemRegistroTransacaoBancoResponse (int IdTransacao,DateTime DataRegistro, string NomeTipoRegistro, string NomePessoa, string NomeBanco);

