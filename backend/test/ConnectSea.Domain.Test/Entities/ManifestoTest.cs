using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Test.Entities;

[Trait("Category", "Domain Entities")]
public class ManifestoTest
{
    [Fact]
    public void Test_Manifesto_Enum_TipoManifesto()
    {
        // Arrange
        const int importacao = (int)TipoManifesto.Importacao;
        const int exportacao = (int)TipoManifesto.Exportacao;

        // Assert
        Assert.Equal(1, importacao);
        Assert.Equal(2, exportacao);
    }

    [Theory]
    [InlineData("MNFT123", TipoManifesto.Importacao, "Navio A", "Porto X", "Porto Y")]
    [InlineData("MNFT456", TipoManifesto.Exportacao, "Navio B", "Porto Y", "Porto Z")]
    public void Test_Create_Manifesto_Instance(string numero, TipoManifesto tipo, string navio, string portoOrigem,
        string portoDestino)
    {
        // Act
        var manifesto = new ConnectSea.Domain.Entities.Manifesto(numero, tipo, navio, portoOrigem, portoDestino);

        // Assert
        Assert.Equal(numero, manifesto.Numero);
        Assert.Equal(tipo, manifesto.Tipo);
        Assert.Equal(navio, manifesto.Navio);
        Assert.Equal(portoOrigem, manifesto.PortoOrigem);
        Assert.Equal(portoDestino, manifesto.PortoDestino);
    }

}