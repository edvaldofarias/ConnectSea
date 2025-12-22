using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Entities;

public class Manifesto(
    string numero,
    TipoManifesto tipo,
    string navio,
    string portoOrigem,
    string portoDestino) : BaseEntity
{
    public string Numero { get; set; } = numero;
    public TipoManifesto Tipo { get; set; } = tipo;
    public string Navio { get; set; } = navio;
    public string PortoOrigem { get; set; } = portoOrigem;
    public string PortoDestino { get; set; } = portoDestino;
}
