using ConnectSea.Domain.Enums;
using ConnectSea.Domain.Repositories;
using Moq;

namespace ConnectSea.Domain.Test.Services;

[Trait("Category", "Domain Services")]
public class EscalaServiceTest
{
    [Theory]
    [InlineData("Navio A", "Porto X", StatusEscala.Prevista, 5, 6, 7)]
    [InlineData("Navio B", "Porto Y", StatusEscala.Atracada, 2, 3, 4)]
    [InlineData("Navio C", "Porto Z", StatusEscala.Saiu, 0, 1, 2)]
    [InlineData("Navio D", "Porto W", StatusEscala.Cancelada, -1, 0, 1)]
    public async Task GetEscalasAsync_ShouldReturnEscalas(string navio, string porto, StatusEscala status, int etaCount, int etbCount, int etdCount)
    {
        // Arrange
        var escalas = new List<ConnectSea.Domain.Entities.Escala>
        {
            new(navio, porto, status, DateTimeOffset.UtcNow.AddDays(etaCount),
                DateTimeOffset.UtcNow.AddDays(etbCount), DateTimeOffset.UtcNow.AddDays(etdCount))
        };
        var escalaRepository = new Mock<IEscalaRepository>();
        escalaRepository.Setup(er => er.GetEscalasAsync())
            .ReturnsAsync(escalas);
        var escalaService = new ConnectSea.Domain.Services.EscalaService(escalaRepository.Object);
        
        // Act
        var escalasDto = await escalaService.GetEscalasAsync();
        
        // Assert
        Assert.NotNull(escalasDto);
        Assert.Equal(escalas.Count, escalasDto.Count());
    }
}