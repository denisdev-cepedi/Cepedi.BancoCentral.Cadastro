using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

public class GeneroController : BaseController
{
    private readonly ILogger<GeneroController> _logger;
    private readonly IMediator _mediator;

    public GeneroController(
        ILogger<GeneroController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarGeneroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarGeneroResponse>> CriarGeneroAsync(
        [FromBody] CriarGeneroRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarGeneroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarGeneroResponse>> AtualizarGeneroAsync(
        [FromBody] AtualizarGeneroRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(GetGenerosResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetGenerosResponse>>> GetGeneroAsync()
    {
        var request = new GetGenerosRequest();
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarGeneroResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarGeneroResponse>> DeletarGeneroAsync(
        [FromBody] DeletarGeneroRequest request) => await SendCommand(request);
}
