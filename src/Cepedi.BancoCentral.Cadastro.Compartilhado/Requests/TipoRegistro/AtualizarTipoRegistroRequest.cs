﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class AtualizarTipoRegistroRequest : IRequest<Result<AtualizarTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }
    public string NomeTipo { get; set; } = default!;

}
