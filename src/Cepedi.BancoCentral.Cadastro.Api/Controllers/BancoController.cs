using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Shareable.Requests;
using Cepedi.BancoCentral.Cadastro.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BancoController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<BancoEntity> _logger;

    public BancoController(IMediator mediator, ILogger<BancoEntity> logger) : base(mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarBancoResponse>> CriarBancoAsync([FromBody] CriarBancoRequest request) =>
        await SendCommand(request);

    [HttpDelete]
    [ProducesResponseType(typeof(DeletarBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarBancoResponse>> DeletarBancoAsync([FromBody] DeletarBancoRequest request) =>
        await SendCommand(request);

    [HttpGet("{idBanco:int}")]
    [ProducesResponseType(typeof(ObtemBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemBancoResponse>> ObterBancoAsync(int idBanco)
    {
        var request = new ObtemBancoRequest { IdBanco = idBanco };
        return await SendCommand(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ObtemBancoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemBancoResponse>> ObterListaBancoAsync()
    {
        var request = new ObtemListaBancoRequest();
        return await SendCommand(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarBancoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AtualizarBancoResponse>> AtualizarBancoAsync(
        [FromBody] AtualizarBancoRequest request) => await SendCommand(request);
}
