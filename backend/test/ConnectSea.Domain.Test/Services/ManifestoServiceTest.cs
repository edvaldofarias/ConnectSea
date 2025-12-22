using ConnectSea.Domain.Entities;
using ConnectSea.Domain.Enums;
using ConnectSea.Domain.Repositories;
using Moq;

namespace ConnectSea.Domain.Test.Services;

[Trait("Category", "Domain Services")]
public class ManifestoServiceTest
{
    [Theory]
    [InlineData("MN123", TipoManifesto.Exportacao, "Navio A", "Porto X", "Porto Y")]
    [InlineData("MN456", TipoManifesto.Importacao, "Navio B", "Porto Y", "Porto Z")]
    
    public async Task GetManifestosAsync_ShouldReturnManifestos(string numero, TipoManifesto tipo, string navio, string portoOrigem, string portoDestino)
    {
        // Arrange
        var manifestos = new List<Manifesto>
        {
            new(numero, tipo, navio, portoOrigem, portoDestino)
        };
        var escalaServiceMock = new Mock<IManifestoRepository>();
        escalaServiceMock.Setup(es => es.GetManifestosAsync())
            .ReturnsAsync(manifestos);

        var manifestoService = new ConnectSea.Domain.Services.ManifestoService(escalaServiceMock.Object);

        // Act
        var manifestosDto = await manifestoService.GetManifestosAsync();

        // Assert
        Assert.NotNull(manifestos);
        Assert.Equal(manifestos.Count, manifestosDto.Count());
    }
}