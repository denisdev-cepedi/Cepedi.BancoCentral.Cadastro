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

namespace Cepedi.BancoCentral.Cadastro.Dominio.Tests.Nacionalidade;

public class DeletarNacionalidadeHandlerTests
{
    private readonly INacionalidadeRepository _nacionalidadeRepository = Substitute.For<INacionalidadeRepository>();
    private readonly ILogger<DeletarNacionalidadeHandler> _logger = Substitute.For<ILogger<DeletarNacionalidadeHandler>>();
    private readonly DeletarNacionalidadeHandler _sut;
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();

    public DeletarNacionalidadeHandlerTests()
    {
        _sut = new DeletarNacionalidadeHandler(_nacionalidadeRepository, _logger, _unitOfWork);
    }

    [Fact]
    public async Task DeletarNacionalidadeAsync_QuandoDeletar_DeveRetornarSucesso()
    {
        //Arrange 
        var nacionalidade = new DeletarNacionalidadeRequest { Id = 0 };
        _nacionalidadeRepository.ObterNacionalidadeAsync(It.IsAny<int>())
            .ReturnsForAnyArgs(new NacionalidadeEntity());
        _nacionalidadeRepository.DeletarNacionalidadeAsync(It.IsAny<NacionalidadeEntity>())
            .ReturnsForAnyArgs(new NacionalidadeEntity());

        //Act
        var result = await _sut.Handle(nacionalidade, CancellationToken.None);

        //Assert
        result.Should().BeOfType<Result<DeletarNacionalidadeResponse>>().Which
            .Value.Nacionalidade.Should().NotBeEmpty();
    }
}
