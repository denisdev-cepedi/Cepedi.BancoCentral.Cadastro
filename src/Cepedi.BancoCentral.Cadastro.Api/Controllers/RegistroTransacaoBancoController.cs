using Cepedi.BancoCentral.Cadastro.Compartilhado.DTO;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
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

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarRegistroTransacaoBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarRegistroTransacaoBancoResponse>> DeletarRegistroTransacaoBancoAsync(
               [FromBody] DeletarRegistroTransacaoBancoRequest request) => await SendCommand(request);

    [HttpGet("{idRegistroTransacaoBanco}")]
    [ProducesResponseType(typeof(ObtemRegistroTransacaoBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemRegistroTransacaoBancoResponse>> ObterRegistroTransacaoBancoAsync(int idRegistroTransacaoBanco)
    {
        var request = new ObtemRegistroTransacaoBancoRequest { IdRegistro = idRegistroTransacaoBanco };
        return await SendCommand(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ObtemRegistroTransacaoBancoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ObtemRegistroTransacaoBancoResponse>>> ObterListaRegistroTransacaoBancoAsync()
    {
        var request = new ObtemListaRegistroTransacaoBancoRequest();
        return await SendCommand(request);
    }

    [HttpGet("saldo/{saldo}")]
    [ProducesResponseType(typeof(List<RegistroTransacaoPessoaTipoTransacaoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<RegistroTransacaoPessoaTipoTransacaoDto>>>
        ObterRegistroTransacaoBancoPorSaldoAsync(double saldo)
    {
        var request = new RegistroTransacaoPessoaTipoTransacaoDtoRequest { Saldo = saldo };
        return await SendCommand(request);
    }
}
