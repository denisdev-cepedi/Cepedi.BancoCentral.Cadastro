namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;

public record AtualizarEnderecoResponse(string Cep, string Logradouro, string Bairro, string Cidade, string Estado, string Numero, string Pais);
