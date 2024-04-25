using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class EstadoCivilController : BaseController
{
    private readonly ILogger<EstadoCivilController> _logger;
    private readonly IMediator _mediator;

    public EstadoCivilController(
        ILogger<EstadoCivilController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarEstadoCivilResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarEstadoCivilResponse>> CriarEstadoCivilAsync(
        [FromBody] CriarEstadoCivilRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarEstadoCivilResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarEstadoCivilResponse>> AtualizarEstadoCivilAsync(
        [FromBody] AtualizarEstadoCivilRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(GetEstadosCivilResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetEstadosCivilResponse>>> GetEstadoCivilAsync()
    {
        var request = new GetEstadosCivilRequest();
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarEstadoCivilResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarEstadoCivilResponse>> DeletarEstadoCivilAsync(
        [FromBody] DeletarEstadoCivilRequest request) => await SendCommand(request);
}
