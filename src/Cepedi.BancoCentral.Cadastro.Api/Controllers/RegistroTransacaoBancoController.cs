using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class RegistroTransacaoBancoController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public RegistroTransacaoBancoController(ILogger<UserController> logger, IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarRegistroTransacaoBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarRegistroTransacaoBancoResponse>> CriarRegistroTransacaoBancoAsync(
                [FromBody] CriarRegistroTransacaoBancoRequest request) => await SendCommand(request);

    [HttpDelete]
    [ProducesResponseType(typeof(DeletarRegistroTransacaoBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarRegistroTransacaoBancoResponse>> DeletarRegistroTransacaoBancoAsync(
               [FromBody] DeletarRegistroTransacaoBancoRequest request) => await SendCommand(request);
}