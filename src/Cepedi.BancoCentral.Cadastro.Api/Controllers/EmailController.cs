using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : BaseController
{
    private readonly ILogger<EmailController> _logger;
    private readonly IMediator _mediator;

    public EmailController(
        ILogger<EmailController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarEmailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarEmailResponse>> CriarEmailAsync(
        [FromBody] CriarEmailRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarEmailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarEmailResponse>> AtualizarEmailAsync(
        [FromBody] AtualizarEmailRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(PegarEmailsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PegarEmailsResponse>> PegarEmailsAsync(
        [FromBody] PegarEmailsRequest request) => await SendCommand(request);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarEmailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarEmailResponse>> DeletarEmailAsync(
        [FromBody] DeletarEmailRequest request) => await SendCommand(request);
}
