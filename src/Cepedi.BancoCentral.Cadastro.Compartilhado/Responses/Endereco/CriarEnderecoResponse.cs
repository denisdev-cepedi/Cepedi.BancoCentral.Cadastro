namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;

public record CriarEnderecoResponse(string Cep, string Logradouro, string Bairro, string Cidade, string Estado, string Numero, string Pais);
