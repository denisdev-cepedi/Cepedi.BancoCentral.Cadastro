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

    public PixController(
        ILogger<PixController> logger, IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarPixResponse>> CriarPixAsync(
        [FromBody] CriarPixRequest request)
    {
        _logger.LogInformation("Iniciando a criação do Pix.");
        try
        {
            var response = await SendCommand(request);
            _logger.LogInformation("Pix criado com sucesso.");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar Pix.");
            throw;
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(AtualizarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<AtualizarPixResponse>> AtualizarPixAsync(
        [FromBody] AtualizarPixRequest request)
    {
        _logger.LogInformation("Iniciando a atualização do Pix.");
        try
        {
            var response = await SendCommand(request);
            _logger.LogInformation("Pix atualizado com sucesso.");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar Pix.");
            throw;
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPixsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetPixsResponse>>> GetPixAsync()
    {
        _logger.LogInformation("Obtendo lista de Pix.");
        try
        {
            var request = new GetPixsRequest();
            var response = await SendCommand(request);
            _logger.LogInformation("Lista de Pix obtida com sucesso.");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter lista de Pix.");
            throw;
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeletarPixResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarPixResponse>> DeletarPixAsync(
        [FromBody] DeletarPixRequest request)
    {
        _logger.LogInformation("Iniciando a exclusão do Pix.");
        try
        {
            var response = await SendCommand(request);
            _logger.LogInformation("Pix excluído com sucesso.");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir Pix.");
            throw;
        }
    }
}
