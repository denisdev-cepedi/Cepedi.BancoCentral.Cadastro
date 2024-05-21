namespace Cepedi.BancoCentral.Cadastro.Shareable.Responses;

public record DeletarBancoResponse(
    int idBanco,
    string nomeFantasia,
    string nomeReal,
    string cnpj,
    DateTime dataCriacao
);
