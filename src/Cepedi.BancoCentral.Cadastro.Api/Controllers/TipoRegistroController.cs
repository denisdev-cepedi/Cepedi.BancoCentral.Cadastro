using Cepedi.BancoCentral.Cadastro.Compartilhado.Excecoes;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoRegistroController : BaseController
{
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public TipoRegistroController(ILogger<UserController> logger, IMediator mediator) : base(mediator)
        {
                _logger = logger;
                _mediator = mediator;
        }

        // [HttpGet("tiporegistro/{idTipoRegistro}")]
        [HttpPost]
        [ProducesResponseType(typeof(CriarTipoRegistroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CriarTipoRegistroResponse>> CriarTipoRegistroAsync(
                [FromBody] CriarTipoRegistroRequest request) => await SendCommand(request);

        [HttpDelete]
        [ProducesResponseType(typeof(DeletarTipoRegistroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeletarTipoRegistroResponse>> DeletarTipoRegistroAsync(
                [FromBody] DeletarTipoRegistroRequest request) => await SendCommand(request);


        [HttpGet("{idTipoRegistro}")]
        [ProducesResponseType(typeof(ObtemTipoRegistroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultadoErro), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ObtemTipoRegistroResponse>> ObterTipoRegistroAsync(int idTipoRegistro)
        {
                var request = new ObtemTipoRegistroRequest { IdTipoRegistro = idTipoRegistro };
                return await SendCommand(request);
        }
}
