using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PixController : BaseController
{
    private readonly ILogger<PixController> _logger;
    private readonly IMediator _mediator;

    public PixController( ILogger<PixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarPixRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPixResponse>> CriarPixAsync(
        [FromBody] CriarPixRequest request) => await SendCommand(request);


    [HttpPut]
    [ProducesResponseType(typeof(AtualizarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPixResponse>> AtualizarPixAsync(
        [FromBody] AtualizarPixRequest request) => await SendCommand(request);


    [HttpGet]
    [ProducesResponseType(typeof(GetPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetPixResponse>>> GetPixAsync()
    {
        var request = new GetPixRequest();
        return await SendCommand(request);
    }


    [HttpDelete]
    [ProducesResponseType(typeof(DeletarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarPixResponse>> DeletarPessoaAsync(
        [FromBody] DeletarPixRequest request) => await SendCommand(request);

    
}
