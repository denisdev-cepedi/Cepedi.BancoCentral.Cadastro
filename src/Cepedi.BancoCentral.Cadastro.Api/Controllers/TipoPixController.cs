using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoPixController : BaseController
{
    private readonly ILogger<TipoPixController> _logger;
    private readonly IMediator _mediator;

    public TipoPixController( ILogger<TipoPixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarTipoPixRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarTipoPixResponse>> CriarTipoPixAsync(
        [FromBody] CriarTipoPixRequest request) => await SendCommand(request);


    [HttpPut]
    [ProducesResponseType(typeof(AtualizarTipoPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarTipoPixResponse>> AtualizarTipoPixAsync(
        [FromBody] AtualizarTipoPixRequest request) => await SendCommand(request);


    [HttpGet]
    [ProducesResponseType(typeof(GetTiposPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetTiposPixResponse>>> GetTipoPixAsync()
    {
        var request = new GetTiposPixRequest();
        return await SendCommand(request);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarTipoPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarTipoPixResponse>> DeletarTipoPessoaAsync(
        [FromBody] DeletarTipoPixRequest request) => await SendCommand(request);

}
