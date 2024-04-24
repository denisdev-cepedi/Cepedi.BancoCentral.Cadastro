using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : BaseController
{
    private readonly ILogger<EnderecoController> _logger;
    private readonly IMediator _mediator;

    public EnderecoController(
        ILogger<EnderecoController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarEnderecoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarEnderecoResponse>> CriarEnderecoAsync(
        [FromBody] CriarEnderecoRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarEnderecoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarEnderecoResponse>> AtualizarEnderecoAsync(
        [FromBody] AtualizarEnderecoRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(GetEnderecosResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetEnderecosResponse>>> GetEnderecoAsync()
    {
        var request = new GetEnderecosRequest();
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarEnderecoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarEnderecoResponse>> DeletarEnderecoAsync(
        [FromBody] DeletarEnderecoRequest request) => await SendCommand(request);
}
