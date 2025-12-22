using ConnectSea.Domain.Enums;

namespace ConnectSea.Domain.Entities;

public class Escala(
    string navio,
    string porto,
    StatusEscala status,
    DateTimeOffset eta,
    DateTimeOffset? etb = null,
    DateTimeOffset? etd = null) : BaseEntity
{
    public string Navio { get; set; } = navio;
    public string Porto { get; set; } = porto;
    public StatusEscala Status { get; set; } = status;
    public DateTimeOffset Eta { get; set; } = eta;
    public DateTimeOffset? Etb { get; set; } = etb;
    public DateTimeOffset? Etd { get; set; } = etd;
}
