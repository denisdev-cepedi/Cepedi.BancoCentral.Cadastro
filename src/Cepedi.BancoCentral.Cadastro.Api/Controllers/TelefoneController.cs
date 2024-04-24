using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

public class TelefoneController : BaseController
{
    private readonly ILogger<TelefoneController> _logger;
    private readonly IMediator _mediator;

    public TelefoneController(
        ILogger<TelefoneController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarTelefoneResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarTelefoneResponse>> CriarTelefoneAsync(
        [FromBody] CriarTelefoneRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarTelefoneResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarTelefoneResponse>> AtualizarTelefoneAsync(
        [FromBody] AtualizarTelefoneRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(GetTelefonesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetTelefonesResponse>>> GetTelefoneAsync()
    {
        var request = new GetTelefonesRequest();
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarTelefoneResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarTelefoneResponse>> DeletarTelefoneAsync(
        [FromBody] DeletarTelefoneRequest request) => await SendCommand(request);
}
