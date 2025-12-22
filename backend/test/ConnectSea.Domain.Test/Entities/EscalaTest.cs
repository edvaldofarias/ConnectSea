using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Test.Entities;

[Trait("Category", "Domain Entities")]
public class EscalaTest
{
    [Fact]
    public void Test_Escala_StatusEscala_Enum_Values()
    {
        // Arrange
        const int previstaValue = 1;
        const int atracadaValue = 2;
        const int saiuValue = 3;
        const int canceladaValue = 4;

        // Act
        const StatusEscala prevista = (StatusEscala)previstaValue;
        const StatusEscala atracada = (StatusEscala)atracadaValue;
        const StatusEscala saiu = (StatusEscala)saiuValue;
        const StatusEscala cancelada = (StatusEscala)canceladaValue;

        // Assert
        Assert.Equal(StatusEscala.Prevista, prevista);
        Assert.Equal(StatusEscala.Atracada, atracada);
        Assert.Equal(StatusEscala.Saiu, saiu);
        Assert.Equal(StatusEscala.Cancelada, cancelada);
    }
    
    [Theory]
    [InlineData("Navio A", "Porto X", StatusEscala.Prevista, 5, 6, 7)]
    [InlineData("Navio B", "Porto Y", StatusEscala.Atracada, 2, 3, 4)]
    [InlineData("Navio C", "Porto Z", StatusEscala.Saiu, 0, 1, 2)]
    [InlineData("Navio D", "Porto W", StatusEscala.Cancelada, -1, 0, 1)]
    public void Test_Create_Escala_Instance(string navio, string porto, StatusEscala status, int etaCount, int etbCount, int etdCount)
    {
        // Arrange
        var eta = DateTimeOffset.UtcNow.AddDays(etaCount);
        DateTimeOffset? etb = DateTimeOffset.UtcNow.AddDays(etbCount);
        DateTimeOffset? etd = DateTimeOffset.UtcNow.AddDays(etdCount);

        // Act
        var escala = new ConnectSea.Domain.Entities.Escala(navio, porto, status, eta, etb, etd);

        // Assert
        Assert.Equal(navio, escala.Navio);
        Assert.Equal(porto, escala.Porto);
        Assert.Equal(status, escala.Status);
        Assert.Equal(eta, escala.Eta);
        Assert.Equal(etb, escala.Etb);
        Assert.Equal(etd, escala.Etd);
    }
}