using FluentValidation;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class CriarRegistroTransacaoBancoRequestValidator: AbstractValidator<CriarRegistroTransacaoBancoRequest>
{
    public CriarRegistroTransacaoBancoRequestValidator()
    {
        RuleFor(request => request.Valor).GreaterThan(0).WithMessage("O valor da transação deve ser maior que zero");
    }
}
