namespace Cepedi.BancoCentral.Cadastro.Shareable.Responses;

public record AtualizarBancoResponse(int idBanco, string nomeFantasia, string nomeReal, string cnpj, DateTime dataCriacao);
