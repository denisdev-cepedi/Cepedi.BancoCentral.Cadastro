﻿using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoRegistrosController : BaseController
{
    private readonly ILogger<TipoRegistrosController> _logger;
    private readonly IMediator _mediator;

    public TipoRegistrosController(ILogger<TipoRegistrosController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarTipoRegistroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarTipoRegistroResponse>> CriarTipoRegistroAsync(
            [FromBody] CriarTipoRegistroRequest request) => await SendCommand(request);

    [HttpDelete]
    [ProducesResponseType(typeof(DeletarTipoRegistroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarTipoRegistroResponse>> DeletarTipoRegistroAsync(
            [FromBody] DeletarTipoRegistroRequest request) => await SendCommand(request);

    [HttpGet("{idTipoRegistro}")]
    [ProducesResponseType(typeof(ObtemTipoRegistroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemTipoRegistroResponse>> ObterTipoRegistroAsync(int idTipoRegistro)
    {
        var request = new ObtemTipoRegistroRequest { IdTipoRegistro = idTipoRegistro };
        return await SendCommand(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ObtemTipoRegistroResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]  
    public async Task<ActionResult<List<ObtemTipoRegistroResponse>>> ObterListaTipoRegistroAsync() 
    {
        var request = new ObtemListaTipoRegistroRequest();
        return await SendCommand(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarTipoRegistroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AtualizarTipoRegistroResponse>> AtualizarTipoRegistroAsync(
            [FromBody] AtualizarTipoRegistroRequest request) => await SendCommand(request);
}
