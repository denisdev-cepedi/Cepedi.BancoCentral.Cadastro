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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Genero;

public class DeleterGeneroHandlerTests
{
    private readonly IGeneroRepository _generoRepository = Substitute.For<IGeneroRepository>();
    private readonly ILogger<DeletarGeneroHandler> _logger = Substitute.For<ILogger<DeletarGeneroHandler>>();
    private readonly DeletarGeneroHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public DeleterGeneroHandlerTests()
    {
        _sut = new DeletarGeneroHandler(_generoRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task DeletarGeneroAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var genero = new DeletarGeneroRequest { Id = 0 };
        _generoRepository.ObterGeneroAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new GeneroEntity());
        _generoRepository.DeletarGeneroAsync(It.IsAny<GeneroEntity>())
            .ReturnsForAnyArgs(new GeneroEntity());

        //Act
        var result = await _sut.Handle(genero, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarGeneroResponse>>().Which
            .Value.Genero.Should().NotBeEmpty();
    }
}
