﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;

public class DeletarTipoRegistroRequest : IRequest<Result<DeletarTipoRegistroResponse>>
{
    public int IdTipoRegistro { get; set; }

}
