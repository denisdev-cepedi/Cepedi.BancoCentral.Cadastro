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

public class DeletarTelefoneHandlerTests
{
    private readonly ITelefoneRepository _telefoneRepository = Substitute.For<ITelefoneRepository>();
    private readonly ILogger<DeletarTelefoneHandler> _logger = Substitute.For<ILogger<DeletarTelefoneHandler>>();
    private readonly DeletarTelefoneHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public DeletarTelefoneHandlerTests()
    {
        _sut = new DeletarTelefoneHandler(_telefoneRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task DeletarTelefoneAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var telefone = new DeletarTelefoneRequest { IdTelefone = 0 };
        _telefoneRepository.ObterTelefoneAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new TelefoneEntity());
        _telefoneRepository.DeletarTelefoneAsync(It.IsAny<TelefoneEntity>())
            .ReturnsForAnyArgs(new TelefoneEntity());

        //Act
        var result = await _sut.Handle(telefone, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarTelefoneResponse>>().Which
            .Value.Telefone.Should().NotBeEmpty();
    }
}
