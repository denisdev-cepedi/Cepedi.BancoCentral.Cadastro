using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class NacionalidadeController : BaseController
{
    private readonly ILogger<NacionalidadeController> _logger;
    private readonly IMediator _mediator;

    public NacionalidadeController(
        ILogger<NacionalidadeController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarNacionalidadeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarNacionalidadeResponse>> CriarNacionalidadeAsync(
        [FromBody] CriarNacionalidadeRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarNacionalidadeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarNacionalidadeResponse>> AtualizarNacionalidadeAsync(
        [FromBody] AtualizarNacionalidadeRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(GetNacionalidadesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetNacionalidadesResponse>>> GetNacionalidadeAsync()
    {
        var request = new GetNacionalidadesRequest();
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarNacionalidadeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarNacionalidadeResponse>> DeletarNacionalidadeAsync(
        [FromBody] DeletarNacionalidadeRequest request) => await SendCommand(request);
}
