namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;

public record GetEnderecosResponse(string Cep, string Logradouro, string Bairro, string Cidade, string Estado, string Numero, string Pais);
