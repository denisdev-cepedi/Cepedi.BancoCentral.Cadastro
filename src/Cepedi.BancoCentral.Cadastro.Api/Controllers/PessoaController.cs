using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : BaseController
{
    private readonly ILogger<PessoaController> _logger;
    private readonly IMediator _mediator;

    public PessoaController(
        ILogger<PessoaController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPessoaResponse>> CriarPessoaAsync(
        [FromBody] CriarPessoaRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPessoaResponse>> AtualizarPessoaAsync(
        [FromBody] AtualizarPessoaRequest request) => await SendCommand(request);

    [HttpGet]
    [ProducesResponseType(typeof(PegarPessoasResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PegarPessoasResponse>> PegarPessoasAsync(
        [FromBody] PegarPessoasRequest request) => await SendCommand(request);

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarPessoaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarPessoaResponse>> DeletarPessoaAsync(
        [FromBody] DeletarPessoaRequest request) => await SendCommand(request);
}
