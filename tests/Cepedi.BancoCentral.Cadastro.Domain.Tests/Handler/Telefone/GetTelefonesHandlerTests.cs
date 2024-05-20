using Cepedi.BancoCentral.Cadastro.Dominio.Entidades;
using Cepedi.BancoCentral.Cadastro.Dominio.Handlers;
using Cepedi.BancoCentral.Cadastro.Dominio.Repository;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Requests;
using Cepedi.BancoCentral.Cadastro.Compartilhado.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;
using OperationResult;

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Telefone;

public class GetTelefonesHandlerTests
{
    private readonly ITelefoneRepository _telefoneRepository = Substitute.For<ITelefoneRepository>();
    private readonly ILogger<GetTelefonesHandler> _logger = Substitute.For<ILogger<GetTelefonesHandler>>();
    private readonly GetTelefonesHandler _sut;

    public GetTelefonesHandlerTests()
    {
        _sut = new GetTelefonesHandler(_telefoneRepository, _logger);
    }

    [Fact]
    public async Task GetTelefonesAsync_QuandoObter_DeveRetornarSucesso()
    {
        //Arrange 
        var telefone = new GetTelefonesRequest();
        var telefoneEntities = new List<TelefoneEntity>
        {
            new TelefoneEntity { NumeroTelefone = "999999999" }
        };
        _telefoneRepository.GetTelefonesAsync().ReturnsForAnyArgs(telefoneEntities);

        //Act
        var result = await _sut.Handle(telefone, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<List<GetTelefonesResponse>>>().Which
            .Value.Should().NotBeEmpty();
    }
}
