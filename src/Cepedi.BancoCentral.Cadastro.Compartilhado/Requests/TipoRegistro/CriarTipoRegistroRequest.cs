﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;


public class CriarTipoRegistroRequest : IRequest<Result<CriarTipoRegistroResponse>>
{
    public string NomeTipo { get; set; } = default!;

}
